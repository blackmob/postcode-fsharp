open Fake.DotNet
#r "./packages/FAKE/tools/FakeLib.dll"
open Fake.Core
open Fake.DotNet

open Fake.Core.TargetOperators

open Fake.IO
open Fake.IO.Globbing.Operators
open System.Text.RegularExpressions

// workaround for https://github.com/fsharp/FAKE/issues/1599
let dotnetOptions = 
        let cliPath =
            Process.tryFindFileOnPath "dotnet"
            |> function
                    | Some dotnet when System.IO.File.Exists dotnet -> dotnet
                    | _ -> failwith "Can't find dotnet on path"
        
        { DotNet.Options.Create() with DotNetCliPath = cliPath }

let extractVersionFromBuild build =                 
                let m = Regex.Match(build, @"\d+\.\d+\.\d+\.\d+")
                if m.Success then Some m.Value                
                else None   

let versionNumber =
    match BuildServer.buildVersion with
    | "LocalBuild" -> 
            printfn "Localbuild detected setting version to 1.0.0.0"
            "1.0.0.0"
    | s -> match extractVersionFromBuild s with
            | Some v -> v
            | None -> "1.0.0.0" 

Target.create "GenerateAssemblyInfo" (fun _ ->  

            !! "**/AssemblyInfo.fs" 
            |> Seq.iter (fun f ->
                            AssemblyInfoFile.createFSharp f 
                                    [
                                        AssemblyInfo.Version versionNumber
                                        AssemblyInfo.FileVersion versionNumber                                        
                                    ] 
                        )            
        ) 

Target.create "ExhaustiveTests" (fun _ ->
    !! "**/FSharp.Postcode.Exhaustive.Tests.fsproj"
    |> Seq.iter (fun projectPath -> (
                                    Fake.DotNet.DotNet.test (fun options -> {options with  Common = dotnetOptions }) projectPath
                                    )                                                                
                )
)


Target.create "Test" (fun _ ->
    !! "**/FSharp.Postcode.Tests.fsproj"
    |> Seq.iter (fun projectPath -> (
                                    Fake.DotNet.DotNet.test (fun options -> {options with  Common = dotnetOptions }) projectPath
                                    )                                                                
                )
)


Target.create "Release" (fun _ ->
    let publishOutput = System.IO.Path.Combine(__SOURCE_DIRECTORY__,  "publish")    
    !! "**/FSharp.Postcode.fsproj"
    |> Seq.iter (fun projectPath -> (
                                    Fake.DotNet.DotNet.publish (fun options -> {options with OutputPath = Some publishOutput; Common = dotnetOptions }) projectPath
                                    )                                                                
                )
)


"GenerateAssemblyInfo"
==> "Release"
==> "Test"
==> "ExhaustiveTests"


Target.runOrDefault "Release"