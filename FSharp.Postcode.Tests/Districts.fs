module Districts

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode

[<Fact>]
let ``Extract districts`` () =

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
            ("EC1A 1BB","EC1");
            ("W1A0AX","W1");
            ("NW1W1AA","NW1");
            ("N1C 0AB","N1");
            ("AA9A 9AA","AA9");
            ("A9A 9AA","A9");
            ("A9 9AA","A9");
            ("A99 9AA","A99");
            ("AA9 9AA","AA9");
            ("AA99 9AA","AA99");
            ("N1C 0AB","N1");
            ("AA9A9AA","AA9");
            ("A9A9AA","A9");
            ("A99AA","A9");
            ("A999AA","A99");
            ("AA99AA","AA9");
            ("AA999AA","AA99")|]

     Assert.All(testData, fun (test, expected) -> 
          Assert.Equal(expected,
                         match test |> postcode with
                         | Ok p -> p |> District
                         | Error e -> e                      
          ))   
