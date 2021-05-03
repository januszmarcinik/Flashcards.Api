# OnPremises
# URL="http://localhost:55320/api/decks/OnPremises/cards"

# Azure
# URL="https://jm-flashcards.azurewebsites.net/api/decks/Azure/cards"

TOKEN="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjMwMmNiMDFjLTNkY2ItNGNlNi05YjQ4LTRlMGMxZTY4NDc0MyIsInN1YiI6ImphbnVzekBqYW51c3ptYXJjaW5pay5wbCIsInJvbGUiOiJBZG1pbiIsImp0aSI6IjkyZjJkNjYwLTAzZmUtNDFlYS1hY2Q3LWIwZGI5MjQ0ODc1NCIsImlhdCI6MTYyMDA1MDA3MCwibmJmIjoxNjIwMDUwMDcwLCJleHAiOjE2MjAwNTM2NzAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTUzMjAifQ.WXkZi5zM3fOXWxGt0ctW1N1Wi9vWE_-YNEW6M9OlraQ"

for i in {1..1}
do
    echo $i
    curl -X POST \
        -H "Content-Type: application/json" \
        -H "Authorization: Bearer $TOKEN" \
        -d @sample-card.json \
        -D - -o /dev/null \
        $URL --fail --silent --show-error
done