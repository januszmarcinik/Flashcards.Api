URL="https://jm-flashcards.azurewebsites.net/api/decks/Azure/cards"
TOKEN=""

for i in {1..100}
do
    echo $i
    curl -X POST \
        -H "Content-Type: application/json" \
        -H "Authorization: Bearer $TOKEN" \
        -d @sample-card.json \
        -D - -o /dev/null \
        $URL --fail --silent --show-error
done