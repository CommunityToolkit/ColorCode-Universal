using System;
using Xunit;

namespace ColorCode.Parsing
{
    public class Scope_Class_Facts
    {
        public class Constructor_Facts
        {
            [Fact]
            public void It_will_set_the_name_and_index_and_length_and_children()
            {
                const string name = "The Scope Name";
                const int index = 435;
                const int length = 34;

                Scope scope = new Scope(name, index, length);

                Assert.Equal("The Scope Name", scope.Name);
                Assert.Equal(435, scope.Index);
                Assert.Equal(34, scope.Length);
                Assert.Null(scope.Parent);
                Assert.Empty(scope.Children);
            }

            [Fact]
            public void It_will_throw_when_name_is_null()
            {
                const string name = null;
                const int index = 435;
                const int length = 34;

                Exception ex = Record.Exception(() => new Scope(name, index, length));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("name", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_name_is_empty()
            {
                string name = string.Empty;
                const int index = 435;
                const int length = 34;

                Exception ex = Record.Exception(() => new Scope(name, index, length));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The name argument value must not be empty.", ex.Message);
                Assert.Equal("name", ((ArgumentException)ex).ParamName);
            }
        }

        public class AddChild_Method_Facts
        {
            [Fact]
            public void It_will_add_the_child_scope_to_the_children_collection()
            {
                Scope scope = new Scope("fnord", 0, 0);
                Scope childScope = new Scope("The Child Scope", 0, 0);

                scope.AddChild(childScope);

                Assert.Contains(childScope, scope.Children);
            }

            [Fact]
            public void It_will_set_the_child_scope_parent()
            {
                Scope scope = new Scope("fnord", 0, 0);
                Scope childScope = new Scope("The Child Scope", 0, 0);

                scope.AddChild(childScope);

                Assert.Equal(scope, childScope.Parent);
            }

            [Fact]
            public void It_will_throw_if_child_scope_already_has_parent()
            {
                Scope scope = new Scope("fnord", 0, 0);
                Scope existingParentScope = new Scope("The Parent Scope", 0, 0);
                Scope childScope = new Scope("The Child Scope", 0, 0);
                childScope.Parent = existingParentScope;

                Exception ex = Record.Exception(() => scope.AddChild(childScope));

                Assert.IsType<InvalidOperationException>(ex);
                Assert.Contains("The child scope already has a parent.", ex.Message);
            }
        }
    }
}
