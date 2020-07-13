$namesespace = "spike-dev"

$component = "dapr-api"
$chart = "daprapi"
$projectDir = ".\Dapr.API"
$imgName = "dapr/api"


$helmInstalls =  helm list -n $namesespace -o json | ConvertFrom-Json

$helm = $helmInstalls |  Where-Object {$_.name -eq $component }
$rev = ($helm.revision -as [int]) + 1

$tag = "0.1.$rev";

Write-Host "Deploying $component version $tag"

docker build -f "$projectDir\Dockerfile" . -t $imgName":"$tag --build-arg VERSION=$tag

Write-Host "Helm upgrade"

helm upgrade --install $component $projectDir\charts\$chart --namespace $namesespace --set image.tag=$tag --wait
