namespace IPX800cs.Test.Parsers.v5;

public static class IPX800V5Response
{
    internal const string IOJson = @"[
  {
    ""_id"": 65536,
    ""name"": ""[IPX]Relay cmd 1"",
    ""link0"": 0,
    ""link1"": 12648448,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65537,
    ""name"": ""[IPX]Relay cmd 2"",
    ""link0"": 0,
    ""link1"": 12648449,
    ""virtual"": false,
    ""on"": true
  },
  {
    ""_id"": 65538,
    ""name"": ""[IPX]Relay cmd 3"",
    ""link0"": 0,
    ""link1"": 12648450,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65539,
    ""name"": ""[IPX]Relay cmd 4"",
    ""link0"": 0,
    ""link1"": 12648451,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65540,
    ""name"": ""[IPX]Relay cmd 5"",
    ""link0"": 0,
    ""link1"": 12648452,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65541,
    ""name"": ""[IPX]Relay cmd 6"",
    ""link0"": 0,
    ""link1"": 12648453,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65542,
    ""name"": ""[IPX]Relay cmd 7"",
    ""link0"": 0,
    ""link1"": 12648454,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65543,
    ""name"": ""[IPX]Relay cmd 8"",
    ""link0"": 0,
    ""link1"": 12648455,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65544,
    ""name"": ""[IPX]Relay state 1"",
    ""link0"": 13500416,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65545,
    ""name"": ""[IPX]Relay state 2"",
    ""link0"": 13500417,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": true
  },
  {
    ""_id"": 65546,
    ""name"": ""[IPX]Relay state 3"",
    ""link0"": 13500418,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65547,
    ""name"": ""[IPX]Relay state 4"",
    ""link0"": 13500419,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65548,
    ""name"": ""[IPX]Relay state 5"",
    ""link0"": 13500420,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65549,
    ""name"": ""[IPX]Relay state 6"",
    ""link0"": 13500421,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65550,
    ""name"": ""[IPX]Relay state 7"",
    ""link0"": 13500422,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65551,
    ""name"": ""[IPX]Relay state 8"",
    ""link0"": 13500423,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65552,
    ""name"": ""[IPX]Digital input 1"",
    ""link0"": 12582912,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65553,
    ""name"": ""[IPX]Digital input 2"",
    ""link0"": 12582913,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65554,
    ""name"": ""[IPX]Digital input 3"",
    ""link0"": 12582914,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65555,
    ""name"": ""[IPX]Digital input 4"",
    ""link0"": 12582915,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": true
  },
  {
    ""_id"": 65556,
    ""name"": ""[IPX]Digital input 5"",
    ""link0"": 12582916,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": true
  },
  {
    ""_id"": 65557,
    ""name"": ""[IPX]Digital input 6"",
    ""link0"": 12582917,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": true
  },
  {
    ""_id"": 65558,
    ""name"": ""[IPX]Digital input 7"",
    ""link0"": 12582918,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65559,
    ""name"": ""[IPX]Digital input 8"",
    ""link0"": 12582919,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65560,
    ""name"": ""[IPX]Opto input 1"",
    ""link0"": 14417920,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65561,
    ""name"": ""[IPX]Opto input 2"",
    ""link0"": 14417921,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65562,
    ""name"": ""[IPX]Opto input 3"",
    ""link0"": 14417922,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65563,
    ""name"": ""[IPX]Opto input 4"",
    ""link0"": 14417923,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65564,
    ""name"": ""[IPX]Open coll. state 1"",
    ""link0"": 14548992,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65565,
    ""name"": ""[IPX]Open coll. state 2"",
    ""link0"": 14548993,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65566,
    ""name"": ""[IPX]Open coll. state 3"",
    ""link0"": 14548994,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65567,
    ""name"": ""[IPX]Open coll. state 4"",
    ""link0"": 14548995,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65568,
    ""name"": ""[IPX]Open coll.  1"",
    ""link0"": 0,
    ""link1"": 14483456,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65569,
    ""name"": ""[IPX]Open coll.  2"",
    ""link0"": 0,
    ""link1"": 14483457,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65570,
    ""name"": ""[IPX]Open coll.  3"",
    ""link0"": 0,
    ""link1"": 14483458,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65571,
    ""name"": ""[IPX]Open coll.  4"",
    ""link0"": 0,
    ""link1"": 14483459,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65572,
    ""name"": ""[IPX]Reboot"",
    ""link0"": 0,
    ""link1"": 12779520,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65573,
    ""name"": ""[IPX]Sel BP"",
    ""link0"": 0,
    ""link1"": 9437184,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65574,
    ""name"": ""[XPSU]AC Detection"",
    ""link0"": 9437184,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  },
  {
    ""_id"": 65575,
    ""name"": ""[WEATHER]Day/Night"",
    ""link0"": 8454144,
    ""link1"": 0,
    ""virtual"": false,
    ""on"": false
  }
]";

    internal const string AnaJson = @"[
  {
    ""_id"": 196608,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]NB CONNECTIONS RUNNING"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 196609,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Levels day"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 196610,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Levels day + 1"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 196611,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Levels day + 2"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 196612,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Levels day + 3"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 196613,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Levels day + 4"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 196614,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Levels day + 5"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 196615,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Levels day + 6"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 196616,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Levels day + 7"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262144,
    ""link0"": 12713984,
    ""link1"": 0,
    ""name"": ""[IPX]Analog input 1"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 9919
  },
  {
    ""_id"": 262145,
    ""link0"": 12713985,
    ""link1"": 0,
    ""name"": ""[IPX]Analog input 2"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262146,
    ""link0"": 12713986,
    ""link1"": 0,
    ""name"": ""[IPX]Analog input 3"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262147,
    ""link0"": 12713987,
    ""link1"": 0,
    ""name"": ""[IPX]Analog input 4"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262148,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]PERIOD (CHARGE)"",
    ""unit"": ""%"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262149,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]APP (CHARGE)"",
    ""unit"": ""%"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262150,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]RULE-ENGINE (CHARGE)"",
    ""unit"": ""%"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262151,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]EBX (CHARGE)"",
    ""unit"": ""%"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262152,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]BSP (CHARGE)"",
    ""unit"": ""%"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262153,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Temperature day"",
    ""unit"": ""°C"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262154,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Pressure day"",
    ""unit"": ""hPa"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262155,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Humidity day"",
    ""unit"": ""RH"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262156,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Wind speed day"",
    ""unit"": ""meter/sec"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262157,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Clouds day"",
    ""unit"": ""%"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262158,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Temperature day + 1"",
    ""unit"": ""°C"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262159,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Pressure day + 1"",
    ""unit"": ""hPa"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262160,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Humidity day + 1"",
    ""unit"": ""RH"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262161,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Wind speed day + 1"",
    ""unit"": ""meter/sec"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262162,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Clouds day + 1"",
    ""unit"": ""%"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262163,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Temperature day + 2"",
    ""unit"": ""°C"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262164,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Pressure day + 2"",
    ""unit"": ""hPa"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262165,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Humidity day + 2"",
    ""unit"": ""RH"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262166,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Wind speed day + 2"",
    ""unit"": ""meter/sec"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262167,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Clouds day + 2"",
    ""unit"": ""%"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262168,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Temperature day + 3"",
    ""unit"": ""°C"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262169,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Pressure day + 3"",
    ""unit"": ""hPa"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262170,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Humidity day + 3"",
    ""unit"": ""RH"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262171,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Wind speed day + 3"",
    ""unit"": ""meter/sec"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262172,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Clouds day + 3"",
    ""unit"": ""%"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262173,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Temperature day + 4"",
    ""unit"": ""°C"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262174,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Pressure day + 4"",
    ""unit"": ""hPa"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262175,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Humidity day + 4"",
    ""unit"": ""RH"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262176,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Wind speed day + 4"",
    ""unit"": ""meter/sec"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262177,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Clouds day + 4"",
    ""unit"": ""%"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262178,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Temperature day + 5"",
    ""unit"": ""°C"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262179,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Pressure day + 5"",
    ""unit"": ""hPa"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262180,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Humidity day + 5"",
    ""unit"": ""RH"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262181,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Wind speed day + 5"",
    ""unit"": ""meter/sec"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262182,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Clouds day + 5"",
    ""unit"": ""%"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262183,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Temperature day + 6"",
    ""unit"": ""°C"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262184,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Pressure day + 6"",
    ""unit"": ""hPa"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262185,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Humidity day + 6"",
    ""unit"": ""RH"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262186,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Wind speed day + 6"",
    ""unit"": ""meter/sec"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262187,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Clouds day + 6"",
    ""unit"": ""%"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262188,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Temperature day + 7"",
    ""unit"": ""°C"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262189,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Pressure day + 7"",
    ""unit"": ""hPa"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262190,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Humidity day + 7"",
    ""unit"": ""RH"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262191,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Wind speed day + 7"",
    ""unit"": ""meter/sec"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 262192,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Clouds day + 7"",
    ""unit"": ""%"",
    ""nbdecimal"": 2,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 327680,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]PERIOD (CYCLE)"",
    ""unit"": ""US"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 13
  },
  {
    ""_id"": 327681,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]APP (CYCLE)"",
    ""unit"": ""US"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 327682,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]RULE-ENGINE (CYCLE)"",
    ""unit"": ""US"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 327683,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]EBX (CYCLE)"",
    ""unit"": ""US"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 327684,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]BSP (CYCLE)"",
    ""unit"": ""US"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 7
  },
  {
    ""_id"": 327685,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]HEAP FREE"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 182248
  },
  {
    ""_id"": 327686,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[DIAG]DELTA HEAP FREE"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 327687,
    ""link0"": 9437184,
    ""link1"": 0,
    ""name"": ""[IPX]CLOCK"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 1643661216
  },
  {
    ""_id"": 327688,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Sunrise day"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  },
  {
    ""_id"": 327689,
    ""link0"": 8454144,
    ""link1"": 0,
    ""name"": ""[WEATHER]Sunset day"",
    ""unit"": ""RAW"",
    ""nbdecimal"": 0,
    ""virtual"": false,
    ""value"": 0
  }
]";
}