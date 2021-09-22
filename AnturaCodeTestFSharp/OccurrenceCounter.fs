namespace AnturaCodeTestFSharp

open System.IO

module OccurrenceCounter =

    let charArrayEquals (a : char[]) (b : char[]) = 
        if a.Length <> b.Length then false else
            let pairs = Array.zip a b
            pairs |> Array.fold (fun equal (a',b') -> (a' = b') && equal) true

    let countOccurrencesInString (searchString : string) (wholeString : string) = 
        if searchString.Length < 1 then 0 else
            let searchStringChars = searchString.ToCharArray()
            let strings = Seq.windowed (String.length searchString) wholeString
            strings |> Seq.map (fun s -> charArrayEquals searchStringChars s) |> Seq.fold (fun sum equal -> sum + (if equal then 1 else 0)) 0

    let countOccurrences filename = 
        let fileLines = File.ReadLines filename
        let searchWord = Path.GetFileNameWithoutExtension filename
        fileLines |> Seq.sumBy (countOccurrencesInString searchWord)