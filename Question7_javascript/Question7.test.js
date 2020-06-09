const arrangeBy = require('./Question7');

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

test('Group by key - name', () => {
    const arrangeByName = arrangeBy('name');
    var result = arrangeByName(users);
    expect(result).toBeDefined();
    expect(result['brain']).toHaveLength(2);
    expect(result['john']).toHaveLength(1);

    ['brain', 'john'].forEach( function(key) {
        result[key].forEach( function(item) {
            expect(item).toHaveProperty('name', key);
            expect(item).not.toHaveProperty('id', '4');
        });
    })
});

test('Group by key - id', () => {
    const arrangeByName = arrangeBy('id');
    var result = arrangeByName(users);
    
    ['1','2','3','4'].forEach( function CheckNameField(item) {
        expect(result).toHaveProperty(item);
        expect(result[item]).toHaveLength(1);
        expect(result[item][0]).toHaveProperty('id', parseInt(item));
    }); 
});

test('Group by key - age', () => {
    const arrangeByName = arrangeBy('age');
    var result = arrangeByName(users);
    
    ['30','40'].forEach( function CheckNameField(item) {
        expect(result).toHaveProperty(item);
        expect(result[item]).toHaveLength(1);
        expect(result[item][0]).toHaveProperty('age', parseInt(item));
    }); 
});

test('Group by non-existent key - NaN', () => {
    const arrangeByName = arrangeBy('NaN');
    var result = arrangeByName(users);
    expect(result).toBeDefined();
    expect(result).toMatchObject({});
    expect(result).not.toHaveProperty('NaN');    
});