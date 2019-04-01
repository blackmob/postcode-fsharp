module Validations

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode

[<Fact>]
let ``validate postcode`` () =

     let testData =  [| "L27 8XY" , "L27 8XY" ;
                       "NR103EZ" , "NR103EZ" ;
                       "RG45AY"  , "RG45AY"  ;
                       "NE69 7AW", "NE69 7AW";
                       "SE23 2NF", "SE23 2NF";
                       "MA1 1AA" , "MA1 1AA" ;
                       "BT35 8GE", "BT35 8GE"|]

     Assert.All(testData, fun (test, _) -> Assert.Equal((match postcode test with | Result.Ok _ -> true | Result.Error _ -> false), true))   
