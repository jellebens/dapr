# dapr
Dapr Test Project

hat's brave of you. git clone, and from chart/dapr run: helm install dapr . --namespace dapr-system --set global.tag=edge

install edge version


log-level
--set dapr_operator.logLevel=debug 
--set dapr_placement.logLevel=debug
--set dapr_sidecar_injector.logLevel=debug

nightly
--set global.tag=edge

logs