import toolbox;

toolbox.split(open('./yellow_tripdata_2018-01.csv', 'r'), ',', 100000, 'y2018-01_%s.csv', './yellow', True);
toolbox.split(open('./green_tripdata_2018-01.csv', 'r'), ',', 100000, 'g2018-01_%s.csv', './green', True);
toolbox.split(open('./fhv_tripdata_2018-01.csv', 'r'), ',', 100000, 'fh2018-01_%s.csv', './fhv', True);


