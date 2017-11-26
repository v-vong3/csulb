
function Geography(id, name, level, parent, children) {
    this.geoId = id; // Globally unique identifier
    this.name = name || '';
    this.level = level || '';
    this.parent = parent || null;
    this.children = children || null;
}
Geography.prototype.toString = function () {
    return this.name;
};
Geography.prototype.printHierarchy = function () {
    if(this.parent === null) {
        return this.toString();
    } else {
        return `${this.toString()}, ${this.parent.printHierarchy()}`;
    }
}

function GeographyLevel() {
    return {
        Country: "Country",
        ProvinceState: "Province or State",
        City: "City"
    };
}

function run() {
    console.log(new Geography());
    console.log(new GeographyLevel());
    console.log(GeographyLevel.City);
}

run();

