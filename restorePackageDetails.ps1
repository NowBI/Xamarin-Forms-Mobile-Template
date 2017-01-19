# Restores package details back to their original state after build.
# 		Usage: "restorePackageDetails.ps1"

function RestoreFile($file) {
	if( (Test-Path "$file.bak")){
		Move-Item "$file.bak" "$file" -force;
	}
}

$manifests = Get-ChildItem Source/*/Properties/AndroidManifest.xml;
$plists = Get-ChildItem Source/*/Info.plist;

foreach($manifest in $manifests){
	RestoreFile $manifest;
}

foreach($plist in $plists){
	RestoreFile $plist;
}