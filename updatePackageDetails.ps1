# This file will update the android manifests and info.plist files to new version and package names if needed.
# This is a very handy tool for updating continuous integration stuff
# 		Usage: "updatePackageDetails.ps1 versionNumber versionName <[packageName] [packageReplacement]>"

function Syntax {
	Write-Host "Usage: 'updatePackageDetails.ps1 versionNumber versionName <[packageName] [packageReplacement]>'"
	Exit
}

if ( $args.Length -eq 0  -or $args[0] -eq "/?" -or $args.Length -eq 1 -or $args.Length -eq 3 ) {
    Syntax;
} else {
	$vNumb=$args[0];
	$vName=$args[1];
	if( $args.Length -eq 4 ) {
		$pName=$args[2];
		$pRepl=$args[3];
	}
}

function BackupFile($file) {
	if( (Test-Path "$file.bak")){
		Move-Item "$file.bak" "$file" -force;
	}
	Copy-Item "$file" "$file.bak";
}

function UpdateManifest($file){
	BackupFile $file;
	Write-Host "Updating $file";
	[xml]$xml = Get-Content "$file";
	$nodes = $xml.SelectNodes("/manifest");
	foreach($node in $nodes) {
		$node.SetAttribute("android:versionCode", "$vNumb");
		$node.SetAttribute("android:versionName", "$vName");
		if( $pName -and $pRepl ){
			$package = $node.GetAttribute("package");
			$package = $package -replace "$pName", "$pRepl";
			$node.SetAttribute("package", "$package");
		}
	}
	$xml.Save("$file");
}

function SetNodeText($node, $text){
	$node.'#text' = "$text";
}

function ReplaceNodeText($node, $find, $replace){
	$text = $node.'#text' -replace "$find", "$replace";
	SetNodeText $node $text;
}

function UpdatePlist($file){
	BackupFile $file;
	Write-Host "Updating $file";
	[xml]$xml = Get-Content "$file";
	$nodes = $xml.SelectNodes("/plist/dict/key");
	foreach($node in $nodes) {
		switch ($node.'#text') {
			"CFBundleVersion" { SetNodeText $node.get_NextSibling() "$vName"; }
			"CFBundleIdentifier" { 
				if( $pName -and $pRepl ){
					ReplaceNodeText $node.get_NextSibling() "$pName" "$pRepl";
				}
			}
		}
	}
	$xml.Save("$file");
}

$manifests = Get-ChildItem Source/*/Properties/AndroidManifest.xml;
$plists = Get-ChildItem Source/*/Info.plist;

foreach($manifest in $manifests){
	UpdateManifest $manifest;
}

foreach($plist in $plists){
	UpdatePlist $plist;
}