del api-pubic-resolved.yaml

curl -X "GET" ^
  "https://api.swaggerhub.com/apis/turbo-smtp/public/2.0.0-oas3?resolved=true&flatten=false" ^
  -H "accept: application/yaml" ^
  -H "Authorization: 495b66c6-cfeb-495a-a060-5452fcd17765" >> api-pubic-resolved.yaml

rmdir API.TurboSMTP /S/Q

openapi-generator-cli generate -i api-pubic-resolved.yaml -g csharp -o API.TurboSMTP --additional-properties=packageName=API.TurboSMTP,allowUnicodeIdentifiers=false,packageGuid={FAE04EC0-301F-11D3-BF4B-00C04F79EFBC},sortParamsByRequiredFlag=true,targetFramework=net48,validatable=false --global-property modelTests=false

pause