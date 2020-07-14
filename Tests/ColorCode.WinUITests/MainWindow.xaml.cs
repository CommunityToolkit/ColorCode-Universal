// Copyright (c) Microsoft Corporation.  All rights reserved.

using ColorCode.Common;
using ColorCode.Styling;
using ColorCode.WinUI.Common;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Runtime.InteropServices;
using WinRT;

namespace ColorCode.WinUITests
{
    public sealed partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region IInitializeWithWindow

        [ComImport]
        [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IInitializeWithWindow
        {
            void Initialize(IntPtr hwnd);
        }

        // This is the actual wrapper for CSWinRT  
        [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
        internal class InitializeWithWindowWrapper : IInitializeWithWindow
        {
            [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
            public struct Vftbl
            {
                public delegate int _Initialize_0(IntPtr thisPtr, IntPtr hwnd);

                internal global::WinRT.Interop.IUnknownVftbl IUnknownVftbl;
                public _Initialize_0 Initialize_0;

                public static readonly Vftbl AbiToProjectionVftable;
                public static readonly IntPtr AbiToProjectionVftablePtr;

                static Vftbl()
                {
                    AbiToProjectionVftable = new Vftbl
                    {
                        IUnknownVftbl = global::WinRT.Interop.IUnknownVftbl.AbiToProjectionVftbl,
                        Initialize_0 = Do_Abi_Initialize_0
                    };
                    AbiToProjectionVftablePtr = Marshal.AllocHGlobal(Marshal.SizeOf<Vftbl>());
                    Marshal.StructureToPtr(AbiToProjectionVftable, AbiToProjectionVftablePtr, false);
                }

                private static int Do_Abi_Initialize_0(IntPtr thisPtr, IntPtr windowHandle)
                {
                    try
                    {
                        ComWrappersSupport.FindObject<IInitializeWithWindow>(thisPtr).Initialize(windowHandle);
                    }
                    catch (Exception ex)
                    {
                        return Marshal.GetHRForException(ex);
                    }
                    return 0;
                }
            }
            internal static ObjectReference<Vftbl> FromAbi(IntPtr thisPtr) => ObjectReference<Vftbl>.FromAbi(thisPtr);

            public static implicit operator InitializeWithWindowWrapper(IObjectReference obj) => (obj != null) ? new InitializeWithWindowWrapper(obj) : null;
            protected readonly ObjectReference<Vftbl> _obj;
            public IObjectReference ObjRef { get => _obj; }
            public IntPtr ThisPtr => _obj.ThisPtr;
            public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
            public A As<A>() => _obj.AsType<A>();
            public InitializeWithWindowWrapper(IObjectReference obj) : this(obj.As<Vftbl>()) { }
            internal InitializeWithWindowWrapper(ObjectReference<Vftbl> obj)
            {
                _obj = obj;
            }

            public void Initialize(IntPtr windowHandle)
            {
                Marshal.ThrowExceptionForHR(_obj.Vftbl.Initialize_0(ThisPtr, windowHandle));
            }
        }

        #endregion

        private async Task<Tuple<string, ILanguage>> GetCodeFileText()
        {
            try
            {
                var picker = new FileOpenPicker();

                IntPtr windowHandle = (App.Current as App).WindowHandle;
                InitializeWithWindowWrapper initializeWithWindowWrapper = InitializeWithWindowWrapper.FromAbi(picker.ThisPtr);
                initializeWithWindowWrapper.Initialize(windowHandle);

                picker.FileTypeFilter.Add("*");

                var file = await picker.PickSingleFileAsync();
                if (file == null) return null;

                System.Diagnostics.Debugger.Launch();

                string text = "";
                using (var reader = new StreamReader(await file.OpenStreamForReadAsync(), true))
                {
                    text = await reader.ReadToEndAsync();
                }

                ILanguage Language = Languages.FindById(file.FileType.Replace(".", "")) ?? Languages.CSharp;
                return new Tuple<string, ILanguage>(text, Language);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return new Tuple<string, ILanguage>("ERROR", Languages.CSharp);
            }
        }

        private void RenderLight(object sender, RoutedEventArgs e)
        {
            MainGrid.RequestedTheme = ElementTheme.Light;
            Render();
        }

        private void RenderDark(object sender, RoutedEventArgs e)
        {
            MainGrid.RequestedTheme = ElementTheme.Dark;
            Render();
        }

        private async void Render()
        {
            PresentationBlock.Blocks.Clear();

            var result = await GetCodeFileText();
            if (result == null) return;

            var formatter = new RichTextBlockFormatter(MainGrid.RequestedTheme);
            var plainText = formatter.Styles[ScopeName.PlainText];
            MainGrid.Background = (plainText?.Background ?? StyleDictionary.White).GetSolidColorBrush();
            formatter.FormatRichTextBlock(result.Item1, result.Item2, PresentationBlock);
        }

        private void HTMLLight(object sender, RoutedEventArgs e)
        {
            MakeHTML(StyleDictionary.DefaultLight);
        }

        private void HTMLDark(object sender, RoutedEventArgs e)
        {
            MakeHTML(StyleDictionary.DefaultDark);
        }

        private async void MakeHTML(StyleDictionary Styles)
        {
            var result = await GetCodeFileText();
            if (result == null) return;

            var formatter = new HtmlFormatter(Styles);
            var html = formatter.GetHtmlString(result.Item1, result.Item2);

            var tempfile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("HTMLResult.html", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(tempfile, html);

            try
            {
                await Launcher.LaunchFileAsync(tempfile);
            }
            catch { }
        }
    }
}
