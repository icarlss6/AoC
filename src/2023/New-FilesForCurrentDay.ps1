param (
    [Parameter(Mandatory = $true, ValueFromPipeline = $true, ValueFromPipelineByPropertyName = $true)]
    [string]$FullName,
    [string]$OutputPath
)

process {
    # Get the current day number
    $dayNumber = Get-Date -UFormat "%d"

    # Read the content of the file
    $content = Get-Content -Path $FullName

    # Replace "XY" with the day number in the content
    $content = $content -replace "XY", $dayNumber

    # Write the updated content back to the file
    Set-Content -Path $FullName -Value $content

    # Rename the file
    $newFileName = $FullName -replace "XY", $dayNumber
    $newFileName = Split-Path -Leaf $newFileName  # Get the file name without the directory

    if ($OutputPath) {
        # If an output path is provided, use it
        $newFileName = Join-Path -Path $OutputPath -ChildPath $newFileName
    } else {
        # Otherwise, use the same directory as the input file
        $newFileName = Join-Path -Path (Split-Path -Parent $FullName) -ChildPath $newFileName
    }

    Rename-Item -Path $FullName -NewName $newFileName
}