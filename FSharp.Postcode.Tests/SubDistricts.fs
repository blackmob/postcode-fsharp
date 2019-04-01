module SubDistricts 

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode

[<Fact>]
let ``Extract sub districts`` () =

     let testData =  [|("L27 8XY",None);
                       ("NR10 3EZ",None);
                       ("RG4 5AY",None);
                       ("NE69 7AW",None);
                       ("SE23 2NF",None);
                       ("BT35 8GE",None);
                       ("L278XY",None);
                       ("NR103EZ",None);
                       ("RG45AY",None);
                       ("NE697AW",None);
                       ("SE232NF",None);
                       ("BT358GE",None);
                       ("EC1A 1BB",Some "EC1A");
                       ("W1A0AX",Some "W1A");
                       ("NW1W1AA",Some "NW1W");
                       ("N1C 0AB",Some "N1C");
                       ("AA9A 9AA",Some "AA9A");
                       ("A9A 9AA",Some "A9A");
                       ("A9 9AA",None);
                       ("A99 9AA",None);
                       ("AA9 9AA",None);
                       ("AA99 9AA",None)|]

     Assert.All(testData, fun (test, expected) -> 
          Assert.Equal(expected,
                         match test |> postcode with
                         | Ok p -> p |> SubDistrict
                         | Error _ -> None                     
          ))   
