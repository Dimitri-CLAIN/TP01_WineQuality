SRC		=	TP01_WineQuality/IKNN.cs	\
			TP01_WineQuality/IWine.cs	\
			TP01_WineQuality/KNN.cs		\
			TP01_WineQuality/Wine.cs	\
			TP01_WineQuality/Program.cs

RM		=	rm -f

CSHARP	= 	csc

OPT		=	-optimize+

all:
	$(CSHARP) $(OPT) $(SRC)

evaluation:
	mono Program.exe -e Data_WineQuality/test.csv
##mono Program.exe -e Data_WineQuality/test_file.csv -t Data_WineQuality/train_file.csv -k k_value -s sort_algorithm

prediction:
	mono Program.exe -p Data_WineQuality/samples/sample_01.csv
##mono Program.exe -p Data_WineQuality/samples/sample_01.csv -t Data_WineQuality/train_file.csv -k k_value -s sort_algorithm

clean:
	$(RM) *.exe

.PHONY: all clean