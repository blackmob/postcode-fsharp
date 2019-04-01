namespace FSharp.String
    open System
    open System.Text.RegularExpressions

    module Postcode = 
        let private validationRegex = @"^[a-z]{1,2}\d[a-z\d]?\s*\d[a-z]{2}$"
        let private incodeRegex = @"\d[a-z]{2}$"
        let private areaRegex = @"^[a-z]{1,2}"
        let private districtSplitRegex = @"^([a-z]{1,2}\d)([a-z])$"
        let private sectorRegex = @"^[a-z]{1,2}\d[a-z\d]?\s*\d"
        let private unitRegex = @"[a-z]{2}$"
        
        type PostcodeString = private PostcodeString of string
        with
            override a.ToString() = 
                let value = let (PostcodeString s) = a in s
                sprintf "%s" (value)        

            static member Create(p: string) = 
                match Regex.Match(p.Trim(), validationRegex, RegexOptions.IgnoreCase ).Success with 
                    | true  -> Result.Ok (PostcodeString p)
                    | false -> Result.Error "Invalid Postcode"  

        let private parseOutcode (p: PostcodeString) =
            Regex.Replace(p.ToString(), incodeRegex, "", RegexOptions.IgnoreCase).Trim().ToUpper()
        
        let private parseIncode (p : PostcodeString) =
            Regex.Match(p.ToString().Trim(), incodeRegex, RegexOptions.IgnoreCase).Value.ToUpper()
        
        let private parseArea (p : PostcodeString) =
            Regex.Match(p.ToString().Trim(), areaRegex, RegexOptions.IgnoreCase).Value.ToUpper()
        
        let private parseSector (p : PostcodeString) =
            Regex.Match(p.ToString().Trim(), sectorRegex, RegexOptions.IgnoreCase).Value.ToUpper()
        
        let private parseUnit (p : PostcodeString) =
            Regex.Match(p.ToString().Trim(), unitRegex, RegexOptions.IgnoreCase).Value.ToUpper()         
               
        
        [<AutoOpen>]
        module PostcodeStringTopLevelOperations = 
            let inline postcode (p: string) = PostcodeString.Create(p) 

            let Normalise (p: PostcodeString) =
                PostcodeString (sprintf "%s %s" (p |> parseOutcode) (p |> parseIncode))
                
            let Unit (p: PostcodeString) =
                p |> parseUnit

            let Sector (p : PostcodeString) = 
                p |> Normalise |> parseSector

            let SubDistrict (p : PostcodeString) = 
                let outcode = p |> parseOutcode
                match Regex.Split(outcode, districtSplitRegex, RegexOptions.IgnoreCase).Length > 1 with 
                | true -> Some outcode
                | false -> None

            let Area (p : PostcodeString) = 
                p |> parseArea

            let District (p: PostcodeString) =
                let outcode = p |> parseOutcode                        
                let split = Regex.Split(outcode, districtSplitRegex, RegexOptions.IgnoreCase)
                match split.Length > 1 with
                | true -> split.[1] 
                | false -> outcode 

            let InCode (p : PostcodeString) = 
                p |> parseIncode   

            let OutCode (p : PostcodeString) = 
                p |> parseOutcode                        