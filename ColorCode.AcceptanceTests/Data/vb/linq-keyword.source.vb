Public Class LinqTest
	Public Sub DoSomething()
	
		Dim test = From d In data
                   Aggregate d In data Into data2 = All(True), data3 = Any(True), _
                    data4 = Average(10), data5 = Count(True), data6 = LongCount(True), _
                    data7 = Max(10), data8 = Min(10), data9 = Sum(10)
				   Join d2 In data On d.Key Equals d2.Key
				   Group Join g In data On d.Key Equals g2.Key
				   Group By h = d.Key
				   Skip 10 Take 10
				   Skip While True
				   Take While True
				   Order By h.Key Ascending, h.Key Descending
				   Let w = g.Key
				   Where g.Key == "abc"
				   Select g Distinct
	End Sub
End Class