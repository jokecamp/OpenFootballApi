FOR %%A IN (1 2 3) DO curl -X POST -d @player.json http://localhost:30001/api/players/0 --header "Content-Type:application/json"
