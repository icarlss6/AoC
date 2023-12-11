[CmdletBinding()]
param (
    [Parameter(Mandatory = $true, ValueFromPipeline = $true, ValueFromPipelineByPropertyName = $true)]
    [string]$FullName,
    [string]$OutputPath = '.'
)

process {
    # Get the current day number
    $dayNumber = Get-Date -UFormat "%d"

    # Get the new file name
    $newFileName = (Split-Path -Leaf $FullName) -replace "XY", $dayNumber 
    
    # Read the content of the file
    $content = Get-Content -Path $FullName
    
    # Replace "XY" with the day number in the content
    $content = $content -replace "XY", $dayNumber
    
    $newFileFullPath = Join-Path -Path $OutputPath -ChildPath $newFileName

    Set-Content -Path $newFileFullPath -Value $content
}