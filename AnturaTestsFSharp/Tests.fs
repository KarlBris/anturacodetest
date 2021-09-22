namespace AnturaTestsFSharp

open Microsoft.VisualStudio.TestTools.UnitTesting
open AnturaCodeTestFSharp

[<TestClass>]
type AnturaTaskFSharpUnitTest () =

    [<TestMethod>]
    member this.TestCharArrayEquals () =
        let charsA = [|'a';'b'|]
        let charsB = [|'a';'b'|]
        Assert.IsTrue <| OccurrenceCounter.charArrayEquals [||] [||]
        Assert.IsTrue <| OccurrenceCounter.charArrayEquals charsA charsB
        Assert.IsTrue <| OccurrenceCounter.charArrayEquals charsB charsA
        Assert.IsFalse <| OccurrenceCounter.charArrayEquals [|'a';'b'|] [|'a'|]
        Assert.IsFalse <| OccurrenceCounter.charArrayEquals [|'a'|] [|'a';'b'|]
        Assert.IsFalse <| OccurrenceCounter.charArrayEquals [||] [|'a';'b'|]
        Assert.IsFalse <| OccurrenceCounter.charArrayEquals [|'a';'b'|] [||]
        
    [<TestMethod>]
    member this.TestCountOccurrencesInString () =
        Assert.IsTrue ((OccurrenceCounter.countOccurrencesInString "antura" "antura") = 1)
        Assert.IsTrue ((OccurrenceCounter.countOccurrencesInString "antura" "anturantura") = 2)
        Assert.IsTrue ((OccurrenceCounter.countOccurrencesInString "antura" "anturAntura") = 0)
        Assert.IsTrue ((OccurrenceCounter.countOccurrencesInString "antura" "antur a ntura") = 0)
        Assert.IsTrue ((OccurrenceCounter.countOccurrencesInString "antura" "antura ntura") = 1)
        Assert.IsTrue ((OccurrenceCounter.countOccurrencesInString "antura" "a") = 0)
        Assert.IsTrue ((OccurrenceCounter.countOccurrencesInString "a" "antura") = 2)
        Assert.IsTrue ((OccurrenceCounter.countOccurrencesInString "" "antura") = 0)
