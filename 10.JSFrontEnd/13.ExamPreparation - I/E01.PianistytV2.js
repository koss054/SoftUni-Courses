function pianist(input) {
    const piecesToAdd = Number(input.shift());
    let piecesCollection = {};
    const commandParser = {
        Add: addPiece,
        Remove: removePiece,
        ChangeKey: changePieceKey,
    };

    for (let i = 0; i < piecesToAdd; i++) {
        const [piece, composer, key] = input.shift().split("|");
        piecesCollection[piece] = { composer, key };
    }

    for (let i = 0; i < input.length; i++) {
        if (input[i] === "Stop") {
            break;
        }

        const tokens = input[i].split("|");
        const commandToken = tokens[0];
        commandParser[commandToken](...tokens.slice(1));
    }

    for (const piece in piecesCollection) {
        const { key, composer } = piecesCollection[piece];
        console.log(`${piece} -> Composer: ${composer}, Key: ${key}`);
    }

    function addPiece(piece, composer, key) {
        if (!piecesCollection.hasOwnProperty(piece)) {
            piecesCollection[piece] = { composer, key };
            console.log(
                `${piece} by ${composer} in ${key} added to the collection!`
            );
        } else {
            console.log(`${piece} is already in the collection!`);
        }
    }

    function removePiece(piece) {
        if (piecesCollection.hasOwnProperty(piece)) {
            delete piecesCollection[piece];
            console.log(`Successfully removed ${piece}!`);
        } else {
            printMissingPieceError(piece);
        }
    }

    function changePieceKey(piece, newKey) {
        if (piecesCollection.hasOwnProperty(piece)) {
            piecesCollection[piece].key = newKey;
            console.log(`Changed the key of ${piece} to ${newKey}!`);
        } else {
            printMissingPieceError(piece);
        }
    }

    function printMissingPieceError(piece) {
        console.log(
            `Invalid operation! ${piece} does not exist in the collection.`
        );
    }
}

pianist([
    "3",
    "Fur Elise|Beethoven|A Minor",
    "Moonlight Sonata|Beethoven|C# Minor",
    "Clair de Lune|Debussy|C# Minor",
    "Add|Sonata No.2|Chopin|B Minor",
    "Add|Hungarian Rhapsody No.2|Liszt|C# Minor",
    "Add|Fur Elise|Beethoven|C# Minor",
    "Remove|Clair de Lune",
    "ChangeKey|Moonlight Sonata|C# Major",
    "Stop",
]);
