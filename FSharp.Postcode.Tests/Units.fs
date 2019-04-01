module Units

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode

[<Fact>]
let ``extract units`` () =

     let testData =  [|"L27 8XY"  , "XY" ;
                       "NR10 3EZ" , "EZ" ;
                       "RG4 5AY"  , "AY" ;
                       "NE69 7AW" , "AW" ;
                       "SE23 2NF" , "NF" ;
                       "BT35 8GE" , "GE" ;
                       "L278XY"   , "XY" ;
                       "NR103EZ"  , "EZ" ;
                       "RG45AY"   , "AY" ;
                       "NE697AW"  , "AW" ;
                       "SE232NF"  , "NF" ;
                       "BT358GE"  , "GE" ;
                       "AA9A 9AA" , "AA" ;
                       "A9A 9AA"  , "AA" ;
                       "A9 9AA"   , "AA" ;
                       "A99 9AA"  , "AA" ;
                       "AA9 9AA"  , "AA" ;
                       "AA99 9AA" , "AA" ;
                       "AA9A9AA"  , "AA" ;
                       "A9A9AA"   , "AA" ;
                       "A99AA"    , "AA" ;
                       "A999AA"   , "AA" ;
                       "AA99AA"   , "AA" ;
                       "AA999AA"  , "AA" |]

     Assert.All(testData, fun (test, expected) -> 
          Assert.Equal((match postcode test with 
                         | Result.Ok p -> p |> Unit = expected                                     
                         | Result.Error _ -> false), true))   
