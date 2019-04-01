module Tests

open System
open Xunit
open FSharp.Data
open FSharp.String.Postcode
type file = CsvProvider<"postcodes.csv">

[<Fact>]
let ``exhaustive postcode tests`` () =
    let postcodeData = file.Load("postcodes.csv")

    Assert.All(postcodeData.Rows, fun (item) -> Assert.Equal((match postcode item.Postcode with | Result.Ok p -> true | Result.Error e -> false), true))   
