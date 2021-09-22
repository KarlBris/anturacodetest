open System.IO
open AnturaCodeTestFSharp

[<EntryPoint>]
let main argv =
    if Array.length argv = 1 then
        let filename = argv.[0]
        if File.Exists filename then
            try
                let count = OccurrenceCounter.countOccurrences filename
                printfn "found %i" count
                0
            with
            | e -> 
                printfn "The program encountered an error: %s" e.Message
                3
        else
            printfn "The file %s does not exist. Please specify an existing file." filename
            2
    else
        printfn "Please supply exactly one argument (file path) to run the program."
        1
