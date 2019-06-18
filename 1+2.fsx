open System

let sum (str: string) =
    str.Split([|','|], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map Int32.Parse
    |> Array.sum

let Add str =
    match str with
        | "" -> printfn "The summation is %d" 0
        | _ -> printfn "The summation is %d" (sum (str))

Console.ReadKey() |> ignore