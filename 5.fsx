open System

let DefaultDelimiters = [|","; "\n"|]

let Parts (str:string) = 
    match str with
    | _ when str.StartsWith("//") ->
        let sep = str.[2] // expr.[2] represents the third char in the string which is the delimiter
        ([|string sep|], str.[3..])
    | _ -> (DefaultDelimiters, str)

let filtering (str: string) =
    let separator, numbersString = Parts str
    numbersString.Split(separator, StringSplitOptions.RemoveEmptyEntries)
    |> Array.map Int32.Parse

let checkNegatives (str: string) =
    filtering str
    |> Array.filter (fun n -> n < 0) // <-- Ignoring negative numbers

let sum (str: string) =
    filtering str
    |> Array.sum

let Add str =
    match str with
        | "" -> printfn "The summation is %d" 0
        | _ when str.Contains "-" -> 
            printfn "Error: Negatives not allowed %A" (for i in (checkNegatives str) do printf "%d, " i)
        | _ -> printfn "The summation is %d" (sum str)


Console.ReadKey() |> ignore