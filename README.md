# Postcode 

A functional port of the postcode.js library.

## Getting started

The postcode library will not create a PostcodeString type unless it passes validation as a genuine UK postcode.

Examples:

```fsharp

// This will create a validated postcode type and output the string representation of its value.
// An invalid postcode would result in an Error type with a value of 'Invalid Postcode'
printf "The postcode was %s" <| match postcode "L27 8XY" with 
                                | Result.Ok p -> p |> string 
                                | Result.Error e -> e  
```

The functions can be chained together to extract different parts of the postcode 

```fsharp

// This will create a validated postcode type and output the string representation of its outcode value.
// An invalid postcode would result in an Error type with a value of 'Invalid Postcode'
printf "The outcodecode was %s" <| match postcode "L27 8XY" with 
                                | Result.Ok p -> p |> Outcode 
                                | Result.Error e -> e  
                              
```

## Building and developing

Postcode is built with the latest [.NET Core SDK](https://www.microsoft.com/net/download/core).

You can either install [Visual Studio 2017](https://www.visualstudio.com/vs/) which comes with the latest SDK or manually download and install the [.NET SDK 2.1](https://www.microsoft.com/net/download/core).

After installation you should be able to run the `.\build` script to successfully build, test and package the library.

The build script supports the following flags:

- `Release` will build the library
- `Test` will build and test the library
- `ExhaustiveTests` will build and test the library running the exhaustive tests against the full UK postcode list

