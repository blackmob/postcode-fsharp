module Sectors 

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode

[<Fact>]
let ``Extract sectors`` () =

     let testData = [|
            ("L27 8XY","L27 8");
            ("NR10 3EZ","NR10 3");
            ("RG4 5AY","RG4 5");
            ("NE69 7AW","NE69 7");
            ("SE23 2NF","SE23 2");
            ("BT35 8GE","BT35 8");
            ("L278XY","L27 8");
            ("NR103EZ","NR10 3");
            ("RG45AY","RG4 5");
            ("NE697AW","NE69 7");
            ("SE232NF","SE23 2");
            ("BT358GE","BT35 8");
            ("AA9A 9AA","AA9A 9");
            ("A9A 9AA","A9A 9");
            ("A9 9AA","A9 9");
            ("A99 9AA","A99 9");
            ("AA9 9AA","AA9 9");
            ("AA99 9AA","AA99 9");
            ("AA9A9AA","AA9A 9");
            ("A9A9AA","A9A 9");
            ("A99AA","A9 9");
            ("A999AA","A99 9");
            ("AA99AA","AA9 9");
            ("AA999AA","AA99 9")|]

     Assert.All(testData, fun (test, expected) -> 
          Assert.Equal(expected,
                         match test |> postcode with
                         | Ok p -> p |> Sector
                         | Error e -> e                      
          ))   
