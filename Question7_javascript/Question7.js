module.exports = arrangeBy

function arrangeBy(name) {
    let groupBykey = name;
    var groupedObj = new Object();

    function addObject(key, val)
    {
        // create a key with empty array if key does not exist 
        if(groupedObj[key] == null) {
            groupedObj[key] = [];
        }

        // add the value to the key in the dictitionary
        groupedObj[key].push(val);
        // console.log(JSON.stringify(groupedObj));
    }

    function arrangeByName(objects) {
        for (var obj of objects) {
            if(obj[groupBykey]) {
                addObject(obj[groupBykey], obj);
            }
        }
        return groupedObj;
    }

    return arrangeByName;
}

// local execution
const users = [
    {
        id: 1,
        name: 'brain',
    },
    {
        id: 2,
        name: 'john',
    },
    {
        id: 3,
        name: 'brain',
        age: 30
    },
    {
        id: 4,
        age: 40
    }
]

const arrangeByName = arrangeBy('name');
console.log(JSON.stringify(arrangeByName(users)));

