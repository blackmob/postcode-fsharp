module InvalidPostcodes

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode

[<Fact>]
let ``invalid postcodes`` () =

     let testData = [|           
            ("EH1 JS", Error "Invalid Postcode" );
            ("EH1JS", Error "Invalid Postcode" );
            ("EH 1JS", Error "Invalid Postcode" );
            ("Definitely wrong", Error "Invalid Postcode" );
            ("12FSSD", Error "Invalid Postcode" );
            ("1A1 1AA", Error "Invalid Postcode" )|] 

     Assert.All(testData, fun (test, expected) -> 
          Assert.Equal(expected, test |> postcode))   
