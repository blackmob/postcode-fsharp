module Normalisation

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode

[<Fact>]
let ``normalisation`` () =

     let testData = [|           
            ("L27 8XY","L27 8XY");
            ("NR10 3EZ","NR10 3EZ");
            ("ZE1 0AA","ZE1 0AA");
            ("NE69 7AW","NE69 7AW");
            ("SE23 2NF","SE23 2NF")|]


     Assert.All(testData, fun (test, expected) -> 
          Assert.Equal(expected,
                         match test |> postcode with
                         | Ok p -> p |> Normalise |> string  
                         | Error e -> e                      
          ))   
