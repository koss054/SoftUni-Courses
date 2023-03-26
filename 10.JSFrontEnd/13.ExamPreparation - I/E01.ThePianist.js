function getPianistPieceInfo(input) {
    class Pianist {
        constructor() {
            this.pieces = [];
        }

        addPiece(pieceName, composer, key, shouldPrint) {
            const piece = {
                name: pieceName,
                composer: composer,
                key: key,
            };

            const isAlreadyAdded = this.doesPieceExist(pieceName);

            if (isAlreadyAdded) {
                console.log(`${pieceName} is already in the collection!`);
            } else {
                this.pieces.push(piece);

                if (shouldPrint) {
                    console.log(
                        `${pieceName} by ${composer} in ${key} added to the collection!`
                    );
                }
            }
        }

        removePiece(pieceName) {
            const pieceIndex = this.getPieceIndex(pieceName);

            if (pieceIndex !== -1) {
                this.pieces.splice(pieceIndex, 1);
                console.log(`Successfully removed ${pieceName}!`);
            } else {
                console.log(
                    `Invalid operation! ${pieceName} does not exist in the collection.`
                );
            }
        }

        changeKey(pieceName, newKey) {
            const pieceIndex = this.getPieceIndex(pieceName);

            if (pieceIndex !== -1) {
                this.pieces[pieceIndex].key = newKey;
                console.log(`Changed the key of ${pieceName} to ${newKey}!`);
            } else {
                console.log(
                    `Invalid operation! ${pieceName} does not exist in the collection.`
                );
            }
        }

        printAllPieces() {
            for (const piece of this.pieces) {
                console.log(
                    `${piece.name} -> Composer: ${piece.composer}, Key: ${piece.key}`
                );
            }
        }

        doesPieceExist(pieceName) {
            return this.pieces.map((piece) => piece.name).includes(pieceName);
        }

        getPieceIndex(pieceName) {
            return this.pieces.map((piece) => piece.name).indexOf(pieceName);
        }
    }

    let pianist = new Pianist();
    const totalPieces = Number(input[0]);

    for (let i = 1; i < input.length; i++) {
        if (i <= totalPieces) {
            const [piece, composer, key] = input[i].split("|");
            pianist.addPiece(piece, composer, key, false);
        } else {
            const currentInput = input[i].split("|");
            const inputCommand = currentInput[0];
            const inputPiece = currentInput[1];

            if (inputCommand === "Add") {
                const inputComposer = currentInput[2];
                const inputKey = currentInput[3];
                pianist.addPiece(inputPiece, inputComposer, inputKey, true);
            } else if (inputCommand === "Remove") {
                pianist.removePiece(inputPiece);
            } else if (inputCommand === "ChangeKey") {
                const inputKey = currentInput[2];
                pianist.changeKey(inputPiece, inputKey);
            } else if (inputCommand === "Stop") {
                pianist.printAllPieces();
                return;
            }
        }
    }
}

getPianistPieceInfo([
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
