[CmdletBinding()]
param (
    [int] 
    $Day = (Get-Date).Day   
)

$uri = "https://adventofcode.com/2023/day/$Day/input"

# Create a new Web Session
$webSession = New-Object Microsoft.PowerShell.Commands.WebRequestSession

# Create a new Cookie
$cookie = New-Object System.Net.Cookie

# Set the properties of the Cookie
$cookie.Name = "session"
$cookie.Value = ""
$cookie.Domain = "adventofcode.com"

# Add the Cookie to the Web Session
$webSession.Cookies.Add($cookie)

$day2Digits = Get-Date -UFormat "%d"
# Download the file
$outfile = "$PSScriptRoot\Day$day2Digits.input.txt"
Write-Verbose "Fetching $outfile from $uri"
Invoke-WebRequest -Uri $uri -OutFile $outfile -WebSession $webSession
