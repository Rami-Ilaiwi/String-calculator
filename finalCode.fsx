open System

let DefaultDelimiters = [|","; "\n"|]

let Parts (str:string) = 
    match str with
    | _ when str.StartsWith("//[") ->
        if str.Contains("][") then 
            let mutable strSep = ""
            let mutable tStr = str
            let mutable count = 0
            for i in str.[..str.IndexOf("\n")] do
                if (i.Equals('[')) then
                    tStr <- (str.[count..])
                    strSep <- strSep + tStr.[1..(tStr.IndexOf(']')-1)] + ";"
                count <- count + 1

            let sep1 = strSep.Split([|';'|], StringSplitOptions.RemoveEmptyEntries)
            (sep1, str.[str.IndexOf("\n")..])
        else
            let sep2 = str.[3..str.IndexOf("]") - 1]
            ([|sep2|], str.[str.IndexOf("\n")..])
    | _ when str.StartsWith("//") ->
        let sep = str.[2] // expr.[2] represents the third char in the string which is the delimiter
        ([|string sep|], str.[3..])
    | _ -> (DefaultDelimiters, str)


let filtering (str: string) =
    let separator, numbersString = Parts str
    numbersString.Split(separator, StringSplitOptions.RemoveEmptyEntries)
    |> Array.map Int32.Parse
    |> Array.filter (fun n -> n <= 1000) // <-- Ignoring above 1000

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
            printfn "Error: Negatives not allowed [%s]" <| String.Join(", ", (checkNegatives str))
        | _ -> printfn "The summation is %d" (sum str)

Console.ReadKey() |> ignore