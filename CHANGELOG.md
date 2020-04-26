# Changelog

## v2.x.x (????-??-??)

### FIXED

- When credentials to connect to an IPX800 v4 throw an exception, wasn't the case before (but it was in the case of a IPX800 v3)

## v2.1.2 (2020-04-12)

### FIXED

- Changelog correction

## v2.1.1 (2020-04-12)

### FIXED

- Version v2.1.0 has been built in Debug, not Release

## v2.1.0 (2020-04-12)

### ADDED

- Added methods allowing to get the state of all input, outputs, etc.

### CHANGED

- IPX800 v3 with firmware >= 3.05.42 now use the IPX800 JSON request instead of the globalstatus.xml file  

### FIXED

- Correction of ISerialize implementation in exception classes
- IPX800v2 : Corrected wrong input states when using HTTP due to wrong input order in status.xml file 
  returned by the IPX800 v2 

## v2.0.0 (2019-02-06)

- New version, redeveloped from scratch

## v1.2.0 (2017-06-28)

### CHANGED

- Various modification and corrections in IPX800V4 implementation

## v1.1.1 (2016-11-19)

### FIXED

- correction on IPX800 response parser for non-headed configuration

## v1.1.0 (2016-10-30)

### ADDED 

- IPX800 v4 support

## v1.0.2 (2016-10-02)

### FIXED

- nuget specifications corrections

### CHANGED

- Json lib update

## v1.0.1 (2015-03-20)

### FIXED

- Added a timeout to prevent the application from blocking if IPX800 is not responding.

## v1.0.0 (2015-03-15)

- First public release
