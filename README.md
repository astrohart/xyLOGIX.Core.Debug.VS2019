# xyLOGIX.Core.Debug `class library`

This project provides basic logging functionality.  Its caller-facing interface is designed to mimic that of the more sophisticated [xyLOGIX.Core.Debug](https://github.com/astrohart/xyLOGIX.Core.Debug.VS2019) project.

This project provides stripped-down logging to text files that are appended to, without the bulk of log4net.

## 1. Introduction

The impetus for building this project was:

* to be independent of `log4net` given its revealed cybersecurity vulnerabilities; and
* to be used as a quick-and-dirty logger when you do not want all the baggage that goes with `log4net`.
* to allow the same sort of methods to be used interchangably with many different logging frameworks.  This is made possible using the Strategy Pattern and the `ILoggingInfrastructure` interface.

## 2. Licensing

Copyright (c) 2022-23 by xyLOGIX, LLC.  All rights reserved.

This library is confidential and proprietary and is intended for use in xyLOGIX projects only.