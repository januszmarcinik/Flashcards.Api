### Documentation

| #   | Developing | Production|
| ---------- | ---------- | ---------- |
| branch | develop | master |
| database | local | Flashcards |
| db user | local | FlashcardsUser |
| url | `http://localhost:55320` | `http://api.flashcards.januszmarcinik.pl` |
| publish profile | - | Production.pubxml |
| publish web cmd | `ng serve` | `ng build --prod --base-href / --environment prod` |
| before update-database in PMC | `$env:ASPNETCORE_ENVIRONMENT='Development'` | `$env:ASPNETCORE_ENVIRONMENT='Production'` |
