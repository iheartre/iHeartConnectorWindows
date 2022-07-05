pkg load instrument-control;

point2read = 1000;

client = tcpclient("127.0.0.1", 6000);

plotY = zeros(1, point2read);

for i = 1:point2read
  bytes = read(client, 71);
  line = native2unicode(bytes);
  parts = strsplit (line, ",");

  year = 2000 + str2num(parts{1,1});
  month = str2num(parts{1,2});
  day = str2num(parts{1,3});
  hour = str2num(parts{1,4});
  minute = str2num(parts{1,5});
  second = str2num(parts{1,6});
  millisecond = str2num(parts{1,7});
  millis = str2num(parts{1,8});
  spO2 = str2num(parts{1,9});
  pulse = str2num(parts{1,10});
  ir = str2num(parts{1,11});
  iri = str2num(parts{1,12});
  spO2Status = hex2dec(parts{1,13});
  battery = str2num(parts{1,14})/1000;
  deviceId = str2num(parts{1,15});

  oximeterData(i).year = year;
  oximeterData(i).month = month;
  oximeterData(i).day = day;
  oximeterData(i).hour = hour;
  oximeterData(i).minute = minute;
  oximeterData(i).second = second;
  oximeterData(i).millisecond = millisecond;
  oximeterData(i).millis = millis;
  oximeterData(i).spO2 = spO2;
  oximeterData(i).pulse = pulse;
  oximeterData(i).ir = ir;
  oximeterData(i).iri = iri;
  oximeterData(i).spO2Status = spO2Status;
  oximeterData(i).battery = battery;
  oximeterData(i).deviceId = deviceId;

  plotY(1,i) = ir;
 endfor

plot(plotY);

clear -x oximeterData
