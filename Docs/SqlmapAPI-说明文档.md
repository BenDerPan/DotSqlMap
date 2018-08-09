# Sqlmap API说明文档
## API 接口说明

#### 1.新建任务

**[GET]**：  /task/new


**应答结果**:
```
{
    "taskid": "0c9164c5287876e3", 
    "success": true
}
```

#### 2.删除任务

**[GET]**：  /task/**taskid**/delete


**应答结果**:
```
{
    "success": true
}
```

#### 3.Admin功能接口 - 获取任务列表信息

**[GET]**：  /admin/**taskid**/list


**应答结果**:
```
{
    "tasks": {
        "0c9164c5287876e3": "not running", 
        "9ab793321df71534": "not running", 
        "bbeee119cf486cc3": "not running"
    }, 
    "tasks_num": 3, 
    "success": true
}
```

#### 4.Admin功能接口 - 清空任务列表

**[GET]**：  /admin/**taskid**/flush


**应答结果**:
```
{
    "success": true
}
```

#### 5.获取任务参数配置列表

**[GET]**：  /option/**taskid**/list


**应答结果**:
```
{
    "options": {
        "crawlDepth": null, 
        "osShell": false, 
        "getUsers": false, 
        "getPasswordHashes": false, 
        "excludeSysDbs": false, 
        "ignoreTimeouts": false, 
        "regData": null, 
        "prefix": null, 
        "code": null, 
        "googlePage": 1, 
        "skip": null, 
        "query": null, 
        "randomAgent": false, 
        "osPwn": false, 
        "authType": null, 
        "safeUrl": null, 
        "requestFile": null, 
        "predictOutput": false, 
        "wizard": false, 
        "stopFail": false, 
        "forms": false, 
        "uChar": null, 
        "secondReq": null, 
        "taskid": "845bea51762722e2", 
        "pivotColumn": null, 
        "dropSetCookie": false, 
        "smart": false, 
        "paramExclude": null, 
        "risk": 1, 
        "sqlFile": null, 
        "rParam": null, 
        "getCurrentUser": false, 
        "notString": null, 
        "getRoles": false, 
        "getPrivileges": false, 
        "testParameter": null, 
        "tbl": null, 
        "charset": null, 
        "trafficFile": null, 
        "osSmb": false, 
        "level": 1, 
        "dnsDomain": null, 
        "skipStatic": false, 
        "outputDir": null, 
        "encoding": null, 
        "skipWaf": false, 
        "timeout": 30, 
        "firstChar": null, 
        "torPort": null, 
        "getComments": false, 
        "binaryFields": null, 
        "checkTor": false, 
        "commonTables": false, 
        "direct": null, 
        "tmpPath": null, 
        "titles": false, 
        "getSchema": false, 
        "identifyWaf": false, 
        "paramDel": null, 
        "safeReqFile": null, 
        "regKey": null, 
        "murphyRate": null, 
        "limitStart": null, 
        "crawlExclude": null, 
        "flushSession": false, 
        "loadCookies": null, 
        "csvDel": ",", 
        "offline": false, 
        "method": null, 
        "tmpDir": null, 
        "disablePrecon": false, 
        "osBof": false, 
        "testSkip": null, 
        "invalidLogical": false, 
        "getCurrentDb": false, 
        "hexConvert": false, 
        "proxyFile": null, 
        "answers": null, 
        "host": null, 
        "dependencies": false, 
        "cookie": null, 
        "proxy": null, 
        "regType": null, 
        "optimize": false, 
        "limitStop": null, 
        "search": false, 
        "uFrom": null, 
        "noCast": false, 
        "testFilter": null, 
        "ignoreCode": null, 
        "eta": false, 
        "csrfToken": null, 
        "threads": 1, 
        "logFile": null, 
        "os": null, 
        "col": null, 
        "rFile": null, 
        "proxyCred": null, 
        "verbose": 1, 
        "isDba": false, 
        "updateAll": false, 
        "privEsc": false, 
        "forceDns": false, 
        "getAll": false, 
        "api": true, 
        "url": null, 
        "invalidBignum": false, 
        "regexp": null, 
        "getDbs": false, 
        "freshQueries": false, 
        "uCols": null, 
        "smokeTest": false, 
        "wFile": null, 
        "udfInject": false, 
        "invalidString": false, 
        "tor": false, 
        "forceSSL": false, 
        "beep": false, 
        "noEscape": false, 
        "configFile": null, 
        "scope": null, 
        "authFile": null, 
        "torType": "SOCKS5", 
        "regVal": null, 
        "dummy": false, 
        "checkInternet": false, 
        "safePost": null, 
        "safeFreq": null, 
        "skipUrlEncode": false, 
        "referer": null, 
        "liveTest": false, 
        "retries": 3, 
        "extensiveFp": false, 
        "dumpTable": false, 
        "getColumns": false, 
        "batch": true, 
        "purge": false, 
        "headers": null, 
        "authCred": null, 
        "osCmd": null, 
        "suffix": null, 
        "dbmsCred": null, 
        "regDel": false, 
        "shLib": null, 
        "sitemapUrl": null, 
        "timeSec": 5, 
        "msfPath": null, 
        "dumpAll": false, 
        "getHostname": false, 
        "sessionFile": null, 
        "disableColoring": true, 
        "getTables": false, 
        "listTampers": false, 
        "agent": null, 
        "webRoot": null, 
        "exclude": null, 
        "lastChar": null, 
        "string": null, 
        "dbms": null, 
        "dumpWhere": null, 
        "tamper": null, 
        "ignoreRedirects": false, 
        "hpp": false, 
        "runCase": null, 
        "delay": 0, 
        "evalCode": null, 
        "cleanup": false, 
        "csrfUrl": null, 
        "secondUrl": null, 
        "getBanner": false, 
        "profile": false, 
        "regRead": false, 
        "bulkFile": null, 
        "db": null, 
        "dumpFormat": "CSV", 
        "alert": null, 
        "harFile": null, 
        "nullConnection": false, 
        "user": null, 
        "parseErrors": false, 
        "getCount": false, 
        "dFile": null, 
        "data": null, 
        "regAdd": false, 
        "ignoreProxy": false, 
        "database": "/tmp/sqlmapipc-bD3ObQ", 
        "mobile": false, 
        "googleDork": null, 
        "saveConfig": null, 
        "sqlShell": false, 
        "tech": "BEUSTQ", 
        "textOnly": false, 
        "cookieDel": null, 
        "commonColumns": false, 
        "keepAlive": false
    }, 
    "success": true
}
```

#### 6.获取任务某个配置内容

**[POST]**：  /option/**taskid**/get


**示例参数**：
```
{"option":"url"}
```

**应答结果**:
```
{
    "url": "http://192.168.10.4:8094", 
    "success": true
}
```


#### 7.设置任务配置

**[POST]**：  /option/**taskid**/set


**示例参数**:
```
{"url":"http://192.168.10.4:8094"}
```

**应答结果**:
```
{
    "success": true
}
```


#### 8.开始任务

**[POST]**：  /scan/**taskid**/start


**示例参数**
```
{"url":"http://192.168.10.4:8087"}
```


**应答结果**:
```
{
    "engineid": 20912, 
    "success": true
}
```

#### 9.停止扫描任务

**[GET]**：  /scan/**taskid**/stop


**应答结果**:
```
{
    "message": "Invalid task ID", 
    "success": false
}

{
    "success": true
}
```

#### 10.强制关闭某个扫描任务

**[GET]**：  /scan/**taskid**/kill


**应答结果**:
```
{
    "message": "Invalid task ID", 
    "success": false
}

{
    "success": true
}
```

#### 11.获取任务运行状态

**[GET]**：  /scan/**taskid**/status


**应答结果**:
```
 {
    "status": "terminated", 
    "returncode": 0, 
    "success": true
}
```

#### 12.获取任务扫描结果

**[GET]**：  /scan/**taskid**/data


**应答结果**:
```
{
    "data": [], 
    "success": true, 
    "error": []
}
```

#### 13.获取指定任务从第m条到n条的日志（1<=m<=n）

**[GET]**：  /scan/**taskid**/log/**start**/**end**


**示例参数**
```
start=1
end=3
```


**应答结果**:
```
{
    "log": [
        {
            "message": "testing connection to the target URL", 
            "level": "INFO", 
            "time": "17:18:30"
        }, 
        {
            "message": "the web server responded with an HTTP error code (403) which could interfere with the results of the tests", 
            "level": "WARNING", 
            "time": "17:18:30"
        }, 
        {
            "message": "checking if the target is protected by some kind of WAF/IPS/IDS", 
            "level": "INFO", 
            "time": "17:18:30"
        }
    ], 
    "success": true
}
```

#### 14.获取指定任务全部扫描日志

**[GET]**：  /scan/**taskid**/log


**应答结果**:
```
{
    "log": [
        {
            "message": "testing connection to the target URL", 
            "level": "INFO", 
            "time": "17:18:30"
        }, 
        {
            "message": "the web server responded with an HTTP error code (403) which could interfere with the results of the tests", 
            "level": "WARNING", 
            "time": "17:18:30"
        }, 
        {
            "message": "checking if the target is protected by some kind of WAF/IPS/IDS", 
            "level": "INFO", 
            "time": "17:18:30"
        }, 
        {
            "message": "testing if the target URL content is stable", 
            "level": "INFO", 
            "time": "17:18:30"
        }, 
        {
            "message": "target URL content is stable", 
            "level": "INFO", 
            "time": "17:18:31"
        }, 
        {
            "message": "no parameter(s) found for testing in the provided data (e.g. GET parameter 'id' in 'www.site.com/index.php?id=1')", 
            "level": "CRITICAL", 
            "time": "17:18:31"
        }, 
        {
            "message": "HTTP error codes detected during run:\n403 (Forbidden) - 3 times", 
            "level": "WARNING", 
            "time": "17:18:31"
        }, 
        {
            "message": "testing connection to the target URL", 
            "level": "INFO", 
            "time": "17:22:45"
        }, 
        {
            "message": "the web server responded with an HTTP error code (403) which could interfere with the results of the tests", 
            "level": "WARNING", 
            "time": "17:22:45"
        }, 
        {
            "message": "testing if the target URL content is stable", 
            "level": "INFO", 
            "time": "17:22:45"
        }, 
        {
            "message": "target URL content is stable", 
            "level": "INFO", 
            "time": "17:22:46"
        }, 
        {
            "message": "no parameter(s) found for testing in the provided data (e.g. GET parameter 'id' in 'www.site.com/index.php?id=1')", 
            "level": "CRITICAL", 
            "time": "17:22:46"
        }, 
        {
            "message": "HTTP error codes detected during run:\n403 (Forbidden) - 2 times", 
            "level": "WARNING", 
            "time": "17:22:46"
        }, 
        {
            "message": "testing connection to the target URL", 
            "level": "INFO", 
            "time": "17:23:22"
        }, 
        {
            "message": "the web server responded with an HTTP error code (403) which could interfere with the results of the tests", 
            "level": "WARNING", 
            "time": "17:23:23"
        }, 
        {
            "message": "testing if the target URL content is stable", 
            "level": "INFO", 
            "time": "17:23:23"
        }, 
        {
            "message": "testing connection to the target URL", 
            "level": "INFO", 
            "time": "17:24:38"
        }, 
        {
            "message": "the web server responded with an HTTP error code (403) which could interfere with the results of the tests", 
            "level": "WARNING", 
            "time": "17:24:38"
        }, 
        {
            "message": "testing if the target URL content is stable", 
            "level": "INFO", 
            "time": "17:24:38"
        }
    ], 
    "success": true
}
```

#### 15.下载文件到本地[欠缺实测环境]

**[GET]**：  /download/**taskid**/**target**/**filename:path*


**应答结果**:
```
[欠缺实测环境]
```

