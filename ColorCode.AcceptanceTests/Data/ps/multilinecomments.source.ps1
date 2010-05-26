#-- Public Module Functions
function Exec
{
<#
.SYNOPSIS
Helper function for executing command-line programs.

.DESCRIPTION
This is a helper function that runs a scriptblock and checks the PS variable $lastexitcode to see if an error occcured.
If an error is detected then an exception is thrown.  This function allows you to run command-line programs without
having to explicitly check fthe $lastexitcode variable.

.PARAMETER cmd
The scriptblock to execute.  This scriptblock will typically contain the command-line invocation.
Required

.PARAMETER errorMessage
The error message used for the exception that is thrown.
Optional

.EXAMPLE
exec { svn info $repository_trunk } "Error executing SVN. Please verify SVN command-line client is installed"

This example calls the svn command-line client.

.LINK
Assert
Invoke-psake
Task
Properties
Include
FormatTaskName
TaskSetup
TaskTearDown
#>
  [CmdletBinding()]

  param(
    [Parameter(Position=0,Mandatory=1)][scriptblock]$cmd,
    [Parameter(Position=1,Mandatory=0)][string]$errorMessage = "Error executing command: " + $cmd
  )
     & $cmd
     if ($lastexitcode -ne 0)
     {
        throw $errorMessage
     }
}