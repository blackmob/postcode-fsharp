module Incodes

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode

[<Fact>]
let ``Extract incodes`` () =

     let testData = [|           
               ("L27 8XY ","8XY");
               ("NR10 3EZ","3EZ");
               ("RG4 5AY ","5AY");
               ("NE69 7AW","7AW");
               ("SE23 2NF","2NF");
               ("BT35 8GE","8GE");
               ("L278XY  ","8XY");
               ("NR103EZ ","3EZ");
               ("RG45AY  ","5AY");
               ("NE697AW ","7AW");
               ("SE232NF ","2NF");
               ("BT358GE ","8GE");
               ("AA9A 9AA","9AA");
               ("A9A 9AA ","9AA");
               ("A9 9AA  ","9AA");
               ("A99 9AA ","9AA");
               ("AA9 9AA ","9AA");
               ("AA99 9AA","9AA");
               ("AA9A9AA ","9AA");
               ("A9A9AA  ","9AA");
               ("A99AA   ","9AA");
               ("A999AA  ","9AA");
               ("AA99AA  ","9AA");
               ("AA999AA ","9AA")|]

     Assert.All(testData, fun (test, expected) -> 
          Assert.Equal(expected,
                         match test |> postcode with
                         | Ok p -> p |> InCode |> string  
                         | Error e -> e                      
          ))   
