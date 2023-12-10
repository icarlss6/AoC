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
$cookie.Value = "53616c7465645f5f84f5aebd13a0f0fcf0106597a327b4e5749fc69c3f8f9cb567b90e8865383c497572c0bb613153e8de61fddefcba1d7e6b2e1710c86c30f6"
$cookie.Domain = "adventofcode.com"

# Add the Cookie to the Web Session
$webSession.Cookies.Add($cookie)

$day2Digits = Get-Date -UFormat "%d"
# Download the file
$outfile = "$PSScriptRoot\Day$day2Digits.input.txt"
Write-Verbose "Fetching $outfile from $uri"
Invoke-WebRequest -Uri $uri -OutFile $outfile -WebSession $webSession
