clear;

% Number of data point to record
pointsToRecord = 1000;

% Preallocating data and plot arrays
oximeterData(pointsToRecord) = struct('Timestamp', datetime(),'Millis',0,'SpO2',0,'Pulse',0,'IR',0,'IRIndex',0,'SpO2Status',0,'Battery',0,'DeviceId',0);
plotY(pointsToRecord) = 0;

% Connecting to local iheartRE Connector
client = tcpclient('127.0.0.1', 6000,'ConnectTimeout',1,'Timeout',1);

% Reading data and storing to oximeterData
index = 1;
for i = 1:pointsToRecord
    line = readline(client);
    if strlength(line) < 70
        continue;
    end

    parts = split(line,",");

    Y = str2num(parts(1));
    M = str2num(parts(2));
    D = str2num(parts(4));
    H = str2num(parts(4));
    MI = str2num(parts(5));
    S = str2num(parts(6));
    MS = str2num(parts(7));

    dt = datetime(Y, M, D, H, MI, S, MS);
    
    millis = str2num(parts(8));

    sp02 = str2num(parts(9));
    pulse = str2num(parts(10));

    ir = str2num(parts(11));
    iri = str2num(parts(12));
    sp02Status = hex2dec(parts(13));
    battery = str2num(parts(14))/1000;
    deviceId = str2num(parts(15));

    oximeterData(index) = struct('Timestamp',dt,'Millis',millis,'SpO2',sp02,'Pulse',pulse,'IR',ir,'IRIndex',iri,'SpO2Status',sp02Status,'Battery',battery,'DeviceId',deviceId);
    plotY(index) = ir;
    index = index + 1;
end

plot(plotY);

disp(strcat(int2str(index - 1), ' data points recorded'));

% Clearing all except oximeterData
clearvars -except oximeterData plotY