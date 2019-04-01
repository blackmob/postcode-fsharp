module Outcodes

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode

[<Fact>]
let ``Extract outcodes`` () =

     let testData = [|
                      ("L27 8XY","L27");
                      ("NR10 3EZ","NR10");
                      ("RG4 5AY","RG4");
                      ("NE69 7AW","NE69");
                      ("SE23 2NF","SE23");
                      ("BT35 8GE","BT35");
                      ("L278XY","L27");
                      ("NR103EZ","NR10");
                      ("RG45AY","RG4");
                      ("NE697AW","NE69");
                      ("SE232NF","SE23");
                      ("BT358GE","BT35");
                      ("AA9A 9AA","AA9A");
                      ("A9A 9AA","A9A");
                      ("A9 9AA","A9");
                      ("A99 9AA","A99");
                      ("AA9 9AA","AA9");
                      ("AA99 9AA","AA99");
                      ("AA9A9AA","AA9A");
                      ("A9A9AA","A9A");
                      ("A99AA","A9");
                      ("A999AA","A99");
                      ("AA99AA","AA9");
                      ("AA999AA","AA99")|]

     Assert.All(testData, fun (test, expected) -> 
          Assert.Equal(expected,
                         match test |> postcode with
                         | Ok p -> p |> OutCode
                         | Error e -> e                      
          ))   
