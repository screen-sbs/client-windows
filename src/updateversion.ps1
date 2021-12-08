$version=$args[0]
$versionString='Version("' + $version + '")'

(Get-Content "client\client\My Project\AssemblyInfo.vb") `
    -replace 'Version[(]["]([0-9]+)([.][0-9]+[.][0-9]+[.][0-9]+)["][)]', $versionString |
  Out-File "client\client\My Project\AssemblyInfo.vb"