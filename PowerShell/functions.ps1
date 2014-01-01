param (
    [parameter(Mandatory=$true)]
    [string]
    $param
)

function NotEmpty($info)
{
	$result = $info
	$oneSpaceInfo = $info -creplace ' ', ''
	if([string]::IsNullOrEmpty($oneSpaceInfo))
	{
		$result = "Information is missing"
	}
	return $result
}

$a= NotEmpty($param)
Write-Host $a
Write-Host "HALLO!!!!!"








