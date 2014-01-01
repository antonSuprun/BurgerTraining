function NotEmpty($info)
{
	$result = $info
	$oneSpaceInfo = $description -creplace ' ', ''
	if([string]::IsNullOrEmpty($oneSpaceInfo))
	{
		$result = "Information is missing"
	}
	return $result
}
Write-Host "Hello World!"
$a= NotEmpty('')
Write-Host $a