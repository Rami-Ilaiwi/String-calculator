open System

let sum (str: char[] * string) =
    let delimiters = fst str
    let numbers = snd str
    numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
    |> Array.map Int32.Parse
    |> Array.sum

let Add str =
    match str with
        | "" -> printfn "The summation is %d" 0
        | _ when str.StartsWith "//" -> printfn "The summation is %d" (sum ([|str.[2]|], str.[3..])) // expr.[2] represents the third char in the string which is the delimiter
        | _ -> printfn "The summation is %d" (sum ([|','; '\n'|], str))

Console.ReadKey() |> ignore