module Areas

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode

[<Fact>]
let ``Extract areas`` () =

     let testData = [|
                    ("L27 8XY","L");
                    ("NR10 3EZ","NR");
                    ("RG4 5AY","RG");
                    ("NE69 7AW","NE");
                    ("SE23 2NF","SE");
                    ("BT35 8GE","BT");
                    ("L278XY","L");
                    ("NR103EZ","NR");
                    ("RG45AY","RG");
                    ("NE697AW","NE");
                    ("SE232NF","SE");
                    ("BT358GE","BT");
                    ("AA9A 9AA","AA");
                    ("A9A 9AA","A");
                    ("A9 9AA","A");
                    ("A99 9AA","A");
                    ("AA9 9AA","AA");
                    ("AA99 9AA","AA");
                    ("AA9A9AA","AA");
                    ("A9A9AA","A");
                    ("A99AA","A");
                    ("A999AA","A");
                    ("AA99AA","AA");
                    ("AA999AA","AA")|]


     Assert.All(testData, fun (test, expected) -> 
          Assert.Equal(expected,
                         match test |> postcode with
                         | Ok p -> p |> Area
                         | Error e -> e                      
          ))   
