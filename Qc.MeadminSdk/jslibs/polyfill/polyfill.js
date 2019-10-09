/* Polyfill service v3.40.0
 * For detailed credits and licence information see https://github.com/financial-times/polyfill-service.
 * 
 * Features requested: Array.prototype.forEach,NodeList.prototype.@@iterator,NodeList.prototype.forEach,Promise
 * 
 * - _ESAbstract.ArrayCreate, License: CC0 (required by "_ESAbstract.ArraySpeciesCreate", "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map")
 * - _ESAbstract.Call, License: CC0 (required by "Array.prototype.forEach", "NodeList.prototype.forEach", "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map", "_ESAbstract.ToPrimitive", "_ESAbstract.ToString", "String.prototype.includes", "_ESAbstract.OrdinaryToPrimitive")
 * - _ESAbstract.CreateDataProperty, License: CC0 (required by "_ESAbstract.CreateDataPropertyOrThrow", "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map")
 * - _ESAbstract.CreateDataPropertyOrThrow, License: CC0 (required by "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map")
 * - _ESAbstract.CreateMethodProperty, License: CC0 (required by "Array.prototype.forEach", "NodeList.prototype.forEach", "Object.create", "_ArrayIterator", "NodeList.prototype.@@iterator", "Object.setPrototypeOf", "String.prototype.includes", "Function.prototype.bind", "_Iterator", "Object.assign", "Object.defineProperties", "Object.getPrototypeOf", "Object.getOwnPropertyNames", "Symbol", "Symbol.iterator", "Object.getOwnPropertyDescriptor", "Array.prototype.filter", "Array.prototype.map", "Object.freeze", "Object.keys")
 * - _ESAbstract.Get, License: CC0 (required by "Array.prototype.forEach", "NodeList.prototype.forEach", "Object.assign", "_Iterator", "_ArrayIterator", "NodeList.prototype.@@iterator", "Object.defineProperties", "Object.create", "_ESAbstract.IsRegExp", "String.prototype.includes", "Array.prototype.filter", "Symbol", "Symbol.iterator", "Array.prototype.map", "_ESAbstract.ArraySpeciesCreate", "_ESAbstract.OrdinaryToPrimitive", "_ESAbstract.ToPrimitive", "_ESAbstract.ToString", "_ESAbstract.GetPrototypeFromConstructor", "_ESAbstract.OrdinaryCreateFromConstructor", "_ESAbstract.Construct")
 * - _ESAbstract.HasProperty, License: CC0 (required by "Array.prototype.forEach", "NodeList.prototype.forEach", "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map")
 * - _ESAbstract.IsArray, License: CC0 (required by "_ESAbstract.ArraySpeciesCreate", "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map")
 * - _ESAbstract.IsCallable, License: CC0 (required by "Array.prototype.forEach", "NodeList.prototype.forEach", "Function.prototype.bind", "_Iterator", "_ArrayIterator", "NodeList.prototype.@@iterator", "Array.prototype.filter", "Symbol", "Symbol.iterator", "Array.prototype.map", "_ESAbstract.GetMethod", "_ESAbstract.ToPrimitive", "_ESAbstract.ToString", "String.prototype.includes", "_ESAbstract.OrdinaryToPrimitive")
 * - _ESAbstract.RequireObjectCoercible, License: CC0 (required by "String.prototype.includes", "_ArrayIterator", "NodeList.prototype.@@iterator")
 * - _ESAbstract.ToBoolean, License: CC0 (required by "_ESAbstract.IsRegExp", "String.prototype.includes", "_ArrayIterator", "NodeList.prototype.@@iterator", "Array.prototype.filter", "Symbol", "Symbol.iterator", "_Iterator")
 * - _ESAbstract.ToInteger, License: CC0 (required by "String.prototype.includes", "_ArrayIterator", "NodeList.prototype.@@iterator", "_ESAbstract.ToLength", "Array.prototype.forEach", "NodeList.prototype.forEach")
 * - _ESAbstract.ToLength, License: CC0 (required by "Array.prototype.forEach", "NodeList.prototype.forEach", "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map")
 * - _ESAbstract.ToObject, License: CC0 (required by "Array.prototype.forEach", "NodeList.prototype.forEach", "Object.assign", "_Iterator", "_ArrayIterator", "NodeList.prototype.@@iterator", "Object.defineProperties", "Object.create", "Array.prototype.filter", "Symbol", "Symbol.iterator", "Array.prototype.map", "_ESAbstract.GetV", "_ESAbstract.GetMethod", "_ESAbstract.ToPrimitive", "_ESAbstract.ToString", "String.prototype.includes")
 * - _ESAbstract.GetV, License: CC0 (required by "_ESAbstract.GetMethod", "_ESAbstract.ToPrimitive", "_ESAbstract.ToString", "Array.prototype.forEach", "NodeList.prototype.forEach", "String.prototype.includes", "_ArrayIterator", "NodeList.prototype.@@iterator")
 * - _ESAbstract.GetMethod, License: CC0 (required by "_ESAbstract.ToPrimitive", "_ESAbstract.ToString", "Array.prototype.forEach", "NodeList.prototype.forEach", "String.prototype.includes", "_ArrayIterator", "NodeList.prototype.@@iterator", "_ESAbstract.IsConstructor", "_ESAbstract.ArraySpeciesCreate", "Array.prototype.filter", "Symbol", "Symbol.iterator", "_Iterator", "Array.prototype.map")
 * - _ESAbstract.Type, License: CC0 (required by "Object.create", "_ArrayIterator", "NodeList.prototype.@@iterator", "_ESAbstract.ToString", "Array.prototype.forEach", "NodeList.prototype.forEach", "String.prototype.includes", "Object.defineProperties", "_Iterator", "_ESAbstract.IsRegExp", "_ESAbstract.ToPrimitive", "_ESAbstract.ArraySpeciesCreate", "Array.prototype.filter", "Symbol", "Symbol.iterator", "Array.prototype.map", "_ESAbstract.OrdinaryToPrimitive", "_ESAbstract.IsConstructor", "_ESAbstract.GetPrototypeFromConstructor", "_ESAbstract.OrdinaryCreateFromConstructor", "_ESAbstract.Construct")
 * - _ESAbstract.GetPrototypeFromConstructor, License: CC0 (required by "_ESAbstract.OrdinaryCreateFromConstructor", "_ESAbstract.Construct", "_ESAbstract.ArraySpeciesCreate", "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map")
 * - _ESAbstract.OrdinaryCreateFromConstructor, License: CC0 (required by "_ESAbstract.Construct", "_ESAbstract.ArraySpeciesCreate", "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map")
 * - _ESAbstract.IsConstructor, License: CC0 (required by "_ESAbstract.ArraySpeciesCreate", "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map", "_ESAbstract.Construct")
 * - _ESAbstract.Construct, License: CC0 (required by "_ESAbstract.ArraySpeciesCreate", "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map")
 * - _ESAbstract.ArraySpeciesCreate, License: CC0 (required by "Array.prototype.filter", "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Array.prototype.map")
 * - _ESAbstract.IsRegExp, License: CC0 (required by "String.prototype.includes", "_ArrayIterator", "NodeList.prototype.@@iterator")
 * - _ESAbstract.OrdinaryToPrimitive, License: CC0 (required by "_ESAbstract.ToPrimitive", "_ESAbstract.ToString", "Array.prototype.forEach", "NodeList.prototype.forEach", "String.prototype.includes", "_ArrayIterator", "NodeList.prototype.@@iterator")
 * - _ESAbstract.ToPrimitive, License: CC0 (required by "_ESAbstract.ToString", "Array.prototype.forEach", "NodeList.prototype.forEach", "String.prototype.includes", "_ArrayIterator", "NodeList.prototype.@@iterator")
 * - _ESAbstract.ToString, License: CC0 (required by "Array.prototype.forEach", "NodeList.prototype.forEach", "String.prototype.includes", "_ArrayIterator", "NodeList.prototype.@@iterator", "Array.prototype.filter", "Symbol", "Symbol.iterator", "_Iterator", "Array.prototype.map")
 * - NodeList.prototype.forEach, License: CC0
 * - Object.keys, License: MIT (required by "Symbol", "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Object.assign", "Object.defineProperties", "Object.create")
 * - Object.assign, License: CC0 (required by "_Iterator", "_ArrayIterator", "NodeList.prototype.@@iterator")
 * - Object.setPrototypeOf, License: MIT (required by "_ArrayIterator", "NodeList.prototype.@@iterator")
 * - Promise, License: MIT
 * - String.prototype.includes, License: CC0 (required by "_ArrayIterator", "NodeList.prototype.@@iterator")
 * - Symbol, License: MIT (required by "Symbol.iterator", "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator", "Symbol.toStringTag")
 * - Symbol.iterator, License: MIT (required by "NodeList.prototype.@@iterator", "_Iterator", "_ArrayIterator")
 * - Symbol.toStringTag, License: MIT (required by "_Iterator", "_ArrayIterator", "NodeList.prototype.@@iterator")
 * - _Iterator, License: MIT (required by "_ArrayIterator", "NodeList.prototype.@@iterator")
 * - _ArrayIterator, License: MIT (required by "NodeList.prototype.@@iterator")
 * - NodeList.prototype.@@iterator, License: MIT */

(function (undefined) {

    // _ESAbstract.ArrayCreate
    // 9.4.2.2. ArrayCreate ( length [ , proto ] )
    function ArrayCreate(length /* [, proto] */) { // eslint-disable-line no-unused-vars
        // 1. Assert: length is an integer Number ≥ 0.
        // 2. If length is -0, set length to +0.
        if (1 / length === -Infinity) {
            length = 0;
        }
        // 3. If length>2^32-1, throw a RangeError exception.
        if (length > (Math.pow(2, 32) - 1)) {
            throw new RangeError('Invalid array length');
        }
        // 4. If proto is not present, set proto to the intrinsic object %ArrayPrototype%.
        // 5. Let A be a newly created Array exotic object.
        var A = [];
        // 6. Set A's essential internal methods except for [[DefineOwnProperty]] to the default ordinary object definitions specified in 9.1.
        // 7. Set A.[[DefineOwnProperty]] as specified in 9.4.2.1.
        // 8. Set A.[[Prototype]] to proto.
        // 9. Set A.[[Extensible]] to true.
        // 10. Perform ! OrdinaryDefineOwnProperty(A, "length", PropertyDescriptor{[[Value]]: length, [[Writable]]: true, [[Enumerable]]: false, [[Configurable]]: false}).
        A.length = length;
        // 11. Return A.
        return A;
    }

    // _ESAbstract.Call
    /* global IsCallable */
    // 7.3.12. Call ( F, V [ , argumentsList ] )
    function Call(F, V /* [, argumentsList] */) { // eslint-disable-line no-unused-vars
        // 1. If argumentsList is not present, set argumentsList to a new empty List.
        var argumentsList = arguments.length > 2 ? arguments[2] : [];
        // 2. If IsCallable(F) is false, throw a TypeError exception.
        if (IsCallable(F) === false) {
            throw new TypeError(Object.prototype.toString.call(F) + 'is not a function.');
        }
        // 3. Return ? F.[[Call]](V, argumentsList).
        return F.apply(V, argumentsList);
    }

    // _ESAbstract.CreateDataProperty
    // 7.3.4. CreateDataProperty ( O, P, V )
    // NOTE
    // This abstract operation creates a property whose attributes are set to the same defaults used for properties created by the ECMAScript language assignment operator.
    // Normally, the property will not already exist. If it does exist and is not configurable or if O is not extensible, [[DefineOwnProperty]] will return false.
    function CreateDataProperty(O, P, V) { // eslint-disable-line no-unused-vars
        // 1. Assert: Type(O) is Object.
        // 2. Assert: IsPropertyKey(P) is true.
        // 3. Let newDesc be the PropertyDescriptor{ [[Value]]: V, [[Writable]]: true, [[Enumerable]]: true, [[Configurable]]: true }.
        var newDesc = {
            value: V,
            writable: true,
            enumerable: true,
            configurable: true
        };
        // 4. Return ? O.[[DefineOwnProperty]](P, newDesc).
        try {
            Object.defineProperty(O, P, newDesc);
            return true;
        } catch (e) {
            return false;
        }
    }

    // _ESAbstract.CreateDataPropertyOrThrow
    /* global CreateDataProperty */
    // 7.3.6. CreateDataPropertyOrThrow ( O, P, V )
    function CreateDataPropertyOrThrow(O, P, V) { // eslint-disable-line no-unused-vars
        // 1. Assert: Type(O) is Object.
        // 2. Assert: IsPropertyKey(P) is true.
        // 3. Let success be ? CreateDataProperty(O, P, V).
        var success = CreateDataProperty(O, P, V);
        // 4. If success is false, throw a TypeError exception.
        if (!success) {
            throw new TypeError('Cannot assign value `' + Object.prototype.toString.call(V) + '` to property `' + Object.prototype.toString.call(P) + '` on object `' + Object.prototype.toString.call(O) + '`');
        }
        // 5. Return success.
        return success;
    }

    // _ESAbstract.CreateMethodProperty
    // 7.3.5. CreateMethodProperty ( O, P, V )
    function CreateMethodProperty(O, P, V) { // eslint-disable-line no-unused-vars
        // 1. Assert: Type(O) is Object.
        // 2. Assert: IsPropertyKey(P) is true.
        // 3. Let newDesc be the PropertyDescriptor{[[Value]]: V, [[Writable]]: true, [[Enumerable]]: false, [[Configurable]]: true}.
        var newDesc = {
            value: V,
            writable: true,
            enumerable: false,
            configurable: true
        };
        // 4. Return ? O.[[DefineOwnProperty]](P, newDesc).
        Object.defineProperty(O, P, newDesc);
    }

    // _ESAbstract.Get
    // 7.3.1. Get ( O, P )
    function Get(O, P) { // eslint-disable-line no-unused-vars
        // 1. Assert: Type(O) is Object.
        // 2. Assert: IsPropertyKey(P) is true.
        // 3. Return ? O.[[Get]](P, O).
        return O[P];
    }

    // _ESAbstract.HasProperty
    // 7.3.10. HasProperty ( O, P )
    function HasProperty(O, P) { // eslint-disable-line no-unused-vars
        // Assert: Type(O) is Object.
        // Assert: IsPropertyKey(P) is true.
        // Return ? O.[[HasProperty]](P).
        return P in O;
    }

    // _ESAbstract.IsArray
    // 7.2.2. IsArray ( argument )
    function IsArray(argument) { // eslint-disable-line no-unused-vars
        // 1. If Type(argument) is not Object, return false.
        // 2. If argument is an Array exotic object, return true.
        // 3. If argument is a Proxy exotic object, then
        // a. If argument.[[ProxyHandler]] is null, throw a TypeError exception.
        // b. Let target be argument.[[ProxyTarget]].
        // c. Return ? IsArray(target).
        // 4. Return false.

        // Polyfill.io - We can skip all the above steps and check the string returned from Object.prototype.toString().
        return Object.prototype.toString.call(argument) === '[object Array]';
    }

    // _ESAbstract.IsCallable
    // 7.2.3. IsCallable ( argument )
    function IsCallable(argument) { // eslint-disable-line no-unused-vars
        // 1. If Type(argument) is not Object, return false.
        // 2. If argument has a [[Call]] internal method, return true.
        // 3. Return false.

        // Polyfill.io - Only function objects have a [[Call]] internal method. This means we can simplify this function to check that the argument has a type of function.
        return typeof argument === 'function';
    }

    // _ESAbstract.RequireObjectCoercible
    // 7.2.1. RequireObjectCoercible ( argument )
    // The abstract operation ToObject converts argument to a value of type Object according to Table 12:
    // Table 12: ToObject Conversions
    /*
    |----------------------------------------------------------------------------------------------------------------------------------------------------|
    | Argument Type | Result                                                                                                                             |
    |----------------------------------------------------------------------------------------------------------------------------------------------------|
    | Undefined     | Throw a TypeError exception.                                                                                                       |
    | Null          | Throw a TypeError exception.                                                                                                       |
    | Boolean       | Return argument.                                                                                                                   |
    | Number        | Return argument.                                                                                                                   |
    | String        | Return argument.                                                                                                                   |
    | Symbol        | Return argument.                                                                                                                   |
    | Object        | Return argument.                                                                                                                   |
    |----------------------------------------------------------------------------------------------------------------------------------------------------|
    */
    function RequireObjectCoercible(argument) { // eslint-disable-line no-unused-vars
        if (argument === null || argument === undefined) {
            throw TypeError();
        }
        return argument;
    }

    // _ESAbstract.ToBoolean
    // 7.1.2. ToBoolean ( argument )
    // The abstract operation ToBoolean converts argument to a value of type Boolean according to Table 9:
    /*
    --------------------------------------------------------------------------------------------------------------
    | Argument Type | Result                                                                                     |
    --------------------------------------------------------------------------------------------------------------
    | Undefined     | Return false.                                                                              |
    | Null          | Return false.                                                                              |
    | Boolean       | Return argument.                                                                           |
    | Number        | If argument is +0, -0, or NaN, return false; otherwise return true.                        |
    | String        | If argument is the empty String (its length is zero), return false; otherwise return true. |
    | Symbol        | Return true.                                                                               |
    | Object        | Return true.                                                                               |
    --------------------------------------------------------------------------------------------------------------
    */
    function ToBoolean(argument) { // eslint-disable-line no-unused-vars
        return Boolean(argument);
    }

    // _ESAbstract.ToInteger
    // 7.1.4. ToInteger ( argument )
    function ToInteger(argument) { // eslint-disable-line no-unused-vars
        // 1. Let number be ? ToNumber(argument).
        var number = Number(argument);
        // 2. If number is NaN, return +0.
        if (isNaN(number)) {
            return 0;
        }
        // 3. If number is +0, -0, +∞, or -∞, return number.
        if (1 / number === Infinity || 1 / number === -Infinity || number === Infinity || number === -Infinity) {
            return number;
        }
        // 4. Return the number value that is the same sign as number and whose magnitude is floor(abs(number)).
        return ((number < 0) ? -1 : 1) * Math.floor(Math.abs(number));
    }

    // _ESAbstract.ToLength
    /* global ToInteger */
    // 7.1.15. ToLength ( argument )
    function ToLength(argument) { // eslint-disable-line no-unused-vars
        // 1. Let len be ? ToInteger(argument).
        var len = ToInteger(argument);
        // 2. If len ≤ +0, return +0.
        if (len <= 0) {
            return 0;
        }
        // 3. Return min(len, 253-1).
        return Math.min(len, Math.pow(2, 53) - 1);
    }

    // _ESAbstract.ToObject
    // 7.1.13 ToObject ( argument )
    // The abstract operation ToObject converts argument to a value of type Object according to Table 12:
    // Table 12: ToObject Conversions
    /*
    |----------------------------------------------------------------------------------------------------------------------------------------------------|
    | Argument Type | Result                                                                                                                             |
    |----------------------------------------------------------------------------------------------------------------------------------------------------|
    | Undefined     | Throw a TypeError exception.                                                                                                       |
    | Null          | Throw a TypeError exception.                                                                                                       |
    | Boolean       | Return a new Boolean object whose [[BooleanData]] internal slot is set to argument. See 19.3 for a description of Boolean objects. |
    | Number        | Return a new Number object whose [[NumberData]] internal slot is set to argument. See 20.1 for a description of Number objects.    |
    | String        | Return a new String object whose [[StringData]] internal slot is set to argument. See 21.1 for a description of String objects.    |
    | Symbol        | Return a new Symbol object whose [[SymbolData]] internal slot is set to argument. See 19.4 for a description of Symbol objects.    |
    | Object        | Return argument.                                                                                                                   |
    |----------------------------------------------------------------------------------------------------------------------------------------------------|
    */
    function ToObject(argument) { // eslint-disable-line no-unused-vars
        if (argument === null || argument === undefined) {
            throw TypeError();
        }
        return Object(argument);
    }

    // _ESAbstract.GetV
    /* global ToObject */
    // 7.3.2 GetV (V, P)
    function GetV(v, p) { // eslint-disable-line no-unused-vars
        // 1. Assert: IsPropertyKey(P) is true.
        // 2. Let O be ? ToObject(V).
        var o = ToObject(v);
        // 3. Return ? O.[[Get]](P, V).
        return o[p];
    }

    // _ESAbstract.GetMethod
    /* global GetV, IsCallable */
    // 7.3.9. GetMethod ( V, P )
    function GetMethod(V, P) { // eslint-disable-line no-unused-vars
        // 1. Assert: IsPropertyKey(P) is true.
        // 2. Let func be ? GetV(V, P).
        var func = GetV(V, P);
        // 3. If func is either undefined or null, return undefined.
        if (func === null || func === undefined) {
            return undefined;
        }
        // 4. If IsCallable(func) is false, throw a TypeError exception.
        if (IsCallable(func) === false) {
            throw new TypeError('Method not callable: ' + P);
        }
        // 5. Return func.
        return func;
    }

    // _ESAbstract.Type
    // "Type(x)" is used as shorthand for "the type of x"...
    function Type(x) { // eslint-disable-line no-unused-vars
        switch (typeof x) {
            case 'undefined':
                return 'undefined';
            case 'boolean':
                return 'boolean';
            case 'number':
                return 'number';
            case 'string':
                return 'string';
            case 'symbol':
                return 'symbol';
            default:
                // typeof null is 'object'
                if (x === null) return 'null';
                // Polyfill.io - This is here because a Symbol polyfill will have a typeof `object`.
                if ('Symbol' in this && x instanceof this.Symbol) return 'symbol';
                return 'object';
        }
    }

    // _ESAbstract.GetPrototypeFromConstructor
    /* global Get, Type */
    // 9.1.14. GetPrototypeFromConstructor ( constructor, intrinsicDefaultProto )
    function GetPrototypeFromConstructor(constructor, intrinsicDefaultProto) { // eslint-disable-line no-unused-vars
        // 1. Assert: intrinsicDefaultProto is a String value that is this specification's name of an intrinsic object. The corresponding object must be an intrinsic that is intended to be used as the [[Prototype]] value of an object.
        // 2. Assert: IsCallable(constructor) is true.
        // 3. Let proto be ? Get(constructor, "prototype").
        var proto = Get(constructor, "prototype");
        // 4. If Type(proto) is not Object, then
        if (Type(proto) !== 'object') {
            // a. Let realm be ? GetFunctionRealm(constructor).
            // b. Set proto to realm's intrinsic object named intrinsicDefaultProto.
            proto = intrinsicDefaultProto;
        }
        // 5. Return proto.
        return proto;
    }

    // _ESAbstract.OrdinaryCreateFromConstructor
    /* global GetPrototypeFromConstructor */
    // 9.1.13. OrdinaryCreateFromConstructor ( constructor, intrinsicDefaultProto [ , internalSlotsList ] )
    function OrdinaryCreateFromConstructor(constructor, intrinsicDefaultProto) { // eslint-disable-line no-unused-vars
        var internalSlotsList = arguments[2] || {};
        // 1. Assert: intrinsicDefaultProto is a String value that is this specification's name of an intrinsic object.
        // The corresponding object must be an intrinsic that is intended to be used as the[[Prototype]] value of an object.

        // 2. Let proto be ? GetPrototypeFromConstructor(constructor, intrinsicDefaultProto).
        var proto = GetPrototypeFromConstructor(constructor, intrinsicDefaultProto);

        // 3. Return ObjectCreate(proto, internalSlotsList).
        // Polyfill.io - We do not pass internalSlotsList to Object.create because Object.create does not use the default ordinary object definitions specified in 9.1.
        var obj = Object.create(proto);
        for (var name in internalSlotsList) {
            if (Object.prototype.hasOwnProperty.call(internalSlotsList, name)) {
                Object.defineProperty(obj, name, {
                    configurable: true,
                    enumerable: false,
                    writable: true,
                    value: internalSlotsList[name]
                });
            }
        }
        return obj;
    }

    // _ESAbstract.IsConstructor
    /* global Type */
    // 7.2.4. IsConstructor ( argument )
    function IsConstructor(argument) { // eslint-disable-line no-unused-vars
        // 1. If Type(argument) is not Object, return false.
        if (Type(argument) !== 'object') {
            return false;
        }
        // 2. If argument has a [[Construct]] internal method, return true.
        // 3. Return false.

        // Polyfill.io - `new argument` is the only way  to truly test if a function is a constructor.
        // We choose to not use`new argument` because the argument could have side effects when called.
        // Instead we check to see if the argument is a function and if it has a prototype.
        // Arrow functions do not have a [[Construct]] internal method, nor do they have a prototype.
        return typeof argument === 'function' && !!argument.prototype;
    }

    // _ESAbstract.Construct
    /* global IsConstructor, OrdinaryCreateFromConstructor, Call */
    // 7.3.13. Construct ( F [ , argumentsList [ , newTarget ]] )
    function Construct(F /* [ , argumentsList [ , newTarget ]] */) { // eslint-disable-line no-unused-vars
        // 1. If newTarget is not present, set newTarget to F.
        var newTarget = arguments.length > 2 ? arguments[2] : F;

        // 2. If argumentsList is not present, set argumentsList to a new empty List.
        var argumentsList = arguments.length > 1 ? arguments[1] : [];

        // 3. Assert: IsConstructor(F) is true.
        if (!IsConstructor(F)) {
            throw new TypeError('F must be a constructor.');
        }

        // 4. Assert: IsConstructor(newTarget) is true.
        if (!IsConstructor(newTarget)) {
            throw new TypeError('newTarget must be a constructor.');
        }

        // 5. Return ? F.[[Construct]](argumentsList, newTarget).
        // Polyfill.io - If newTarget is the same as F, it is equivalent to new F(...argumentsList).
        if (newTarget === F) {
            return new (Function.prototype.bind.apply(F, [null].concat(argumentsList)))();
        } else {
            // Polyfill.io - This is mimicking section 9.2.2 step 5.a.
            var obj = OrdinaryCreateFromConstructor(newTarget, Object.prototype);
            return Call(F, obj, argumentsList);
        }
    }

    // _ESAbstract.ArraySpeciesCreate
    /* global IsArray, ArrayCreate, Get, Type, IsConstructor, Construct */
    // 9.4.2.3. ArraySpeciesCreate ( originalArray, length )
    function ArraySpeciesCreate(originalArray, length) { // eslint-disable-line no-unused-vars
        // 1. Assert: length is an integer Number ≥ 0.
        // 2. If length is -0, set length to +0.
        if (1 / length === -Infinity) {
            length = 0;
        }

        // 3. Let isArray be ? IsArray(originalArray).
        var isArray = IsArray(originalArray);

        // 4. If isArray is false, return ? ArrayCreate(length).
        if (isArray === false) {
            return ArrayCreate(length);
        }

        // 5. Let C be ? Get(originalArray, "constructor").
        var C = Get(originalArray, 'constructor');

        // Polyfill.io - We skip this section as not sure how to make a cross-realm normal Array, a same-realm Array.
        // 6. If IsConstructor(C) is true, then
        // if (IsConstructor(C)) {
        // a. Let thisRealm be the current Realm Record.
        // b. Let realmC be ? GetFunctionRealm(C).
        // c. If thisRealm and realmC are not the same Realm Record, then
        // i. If SameValue(C, realmC.[[Intrinsics]].[[%Array%]]) is true, set C to undefined.
        // }
        // 7. If Type(C) is Object, then
        if (Type(C) === 'object') {
            // a. Set C to ? Get(C, @@species).
            C = 'Symbol' in this && 'species' in this.Symbol ? Get(C, this.Symbol.species) : undefined;
            // b. If C is null, set C to undefined.
            if (C === null) {
                C = undefined;
            }
        }
        // 8. If C is undefined, return ? ArrayCreate(length).
        if (C === undefined) {
            return ArrayCreate(length);
        }
        // 9. If IsConstructor(C) is false, throw a TypeError exception.
        if (!IsConstructor(C)) {
            throw new TypeError('C must be a constructor');
        }
        // 10. Return ? Construct(C, « length »).
        return Construct(C, [length]);
    }

    // _ESAbstract.IsRegExp
    /* global Type, Get, ToBoolean */
    // 7.2.8. IsRegExp ( argument )
    function IsRegExp(argument) { // eslint-disable-line no-unused-vars
        // 1. If Type(argument) is not Object, return false.
        if (Type(argument) !== 'object') {
            return false;
        }
        // 2. Let matcher be ? Get(argument, @@match).
        var matcher = 'Symbol' in this && 'match' in this.Symbol ? Get(argument, this.Symbol.match) : undefined;
        // 3. If matcher is not undefined, return ToBoolean(matcher).
        if (matcher !== undefined) {
            return ToBoolean(matcher);
        }
        // 4. If argument has a [[RegExpMatcher]] internal slot, return true.
        try {
            var lastIndex = argument.lastIndex;
            argument.lastIndex = 0;
            RegExp.prototype.exec.call(argument);
            return true;
        } catch (e) { } finally {
            argument.lastIndex = lastIndex;
        }
        // 5. Return false.
        return false;
    }

    // _ESAbstract.OrdinaryToPrimitive
    /* global Get, IsCallable, Call, Type */
    // 7.1.1.1. OrdinaryToPrimitive ( O, hint )
    function OrdinaryToPrimitive(O, hint) { // eslint-disable-line no-unused-vars
        // 1. Assert: Type(O) is Object.
        // 2. Assert: Type(hint) is String and its value is either "string" or "number".
        // 3. If hint is "string", then
        if (hint === 'string') {
            // a. Let methodNames be « "toString", "valueOf" ».
            var methodNames = ['toString', 'valueOf'];
            // 4. Else,
        } else {
            // a. Let methodNames be « "valueOf", "toString" ».
            methodNames = ['valueOf', 'toString'];
        }
        // 5. For each name in methodNames in List order, do
        for (var i = 0; i < methodNames.length; ++i) {
            var name = methodNames[i];
            // a. Let method be ? Get(O, name).
            var method = Get(O, name);
            // b. If IsCallable(method) is true, then
            if (IsCallable(method)) {
                // i. Let result be ? Call(method, O).
                var result = Call(method, O);
                // ii. If Type(result) is not Object, return result.
                if (Type(result) !== 'object') {
                    return result;
                }
            }
        }
        // 6. Throw a TypeError exception.
        throw new TypeError('Cannot convert to primitive.');
    }

    // _ESAbstract.ToPrimitive
    /* global Type, GetMethod, Call, OrdinaryToPrimitive */
    // 7.1.1. ToPrimitive ( input [ , PreferredType ] )
    function ToPrimitive(input /* [, PreferredType] */) { // eslint-disable-line no-unused-vars
        var PreferredType = arguments.length > 1 ? arguments[1] : undefined;
        // 1. Assert: input is an ECMAScript language value.
        // 2. If Type(input) is Object, then
        if (Type(input) === 'object') {
            // a. If PreferredType is not present, let hint be "default".
            if (arguments.length < 2) {
                var hint = 'default';
                // b. Else if PreferredType is hint String, let hint be "string".
            } else if (PreferredType === String) {
                hint = 'string';
                // c. Else PreferredType is hint Number, let hint be "number".
            } else if (PreferredType === Number) {
                hint = 'number';
            }
            // d. Let exoticToPrim be ? GetMethod(input, @@toPrimitive).
            var exoticToPrim = typeof this.Symbol === 'function' && typeof this.Symbol.toPrimitive === 'symbol' ? GetMethod(input, this.Symbol.toPrimitive) : undefined;
            // e. If exoticToPrim is not undefined, then
            if (exoticToPrim !== undefined) {
                // i. Let result be ? Call(exoticToPrim, input, « hint »).
                var result = Call(exoticToPrim, input, [hint]);
                // ii. If Type(result) is not Object, return result.
                if (Type(result) !== 'object') {
                    return result;
                }
                // iii. Throw a TypeError exception.
                throw new TypeError('Cannot convert exotic object to primitive.');
            }
            // f. If hint is "default", set hint to "number".
            if (hint === 'default') {
                hint = 'number';
            }
            // g. Return ? OrdinaryToPrimitive(input, hint).
            return OrdinaryToPrimitive(input, hint);
        }
        // 3. Return input
        return input;
    }

    // _ESAbstract.ToString
    /* global Type, ToPrimitive */
    // 7.1.12. ToString ( argument )
    // The abstract operation ToString converts argument to a value of type String according to Table 11:
    // Table 11: ToString Conversions
    /*
    |---------------|--------------------------------------------------------|
    | Argument Type | Result                                                 |
    |---------------|--------------------------------------------------------|
    | Undefined     | Return "undefined".                                    |
    |---------------|--------------------------------------------------------|
    | Null	        | Return "null".                                         |
    |---------------|--------------------------------------------------------|
    | Boolean       | If argument is true, return "true".                    |
    |               | If argument is false, return "false".                  |
    |---------------|--------------------------------------------------------|
    | Number        | Return NumberToString(argument).                       |
    |---------------|--------------------------------------------------------|
    | String        | Return argument.                                       |
    |---------------|--------------------------------------------------------|
    | Symbol        | Throw a TypeError exception.                           |
    |---------------|--------------------------------------------------------|
    | Object        | Apply the following steps:                             |
    |               | Let primValue be ? ToPrimitive(argument, hint String). |
    |               | Return ? ToString(primValue).                          |
    |---------------|--------------------------------------------------------|
    */
    function ToString(argument) { // eslint-disable-line no-unused-vars
        switch (Type(argument)) {
            case 'symbol':
                throw new TypeError('Cannot convert a Symbol value to a string');
                break;
            case 'object':
                var primValue = ToPrimitive(argument, 'string');
                return ToString(primValue);
            default:
                return String(argument);
        }
    }

    // NodeList.prototype.forEach
    NodeList.prototype.forEach = Array.prototype.forEach;
    // Object.keys
    /* global CreateMethodProperty */
    CreateMethodProperty(Object, "keys", (function () {
        'use strict';

        // modified from https://github.com/es-shims/object-keys

        var has = Object.prototype.hasOwnProperty;
        var toStr = Object.prototype.toString;
        var isEnumerable = Object.prototype.propertyIsEnumerable;
        var hasDontEnumBug = !isEnumerable.call({ toString: null }, 'toString');
        var hasProtoEnumBug = isEnumerable.call(function () { }, 'prototype');
        var dontEnums = [
            'toString',
            'toLocaleString',
            'valueOf',
            'hasOwnProperty',
            'isPrototypeOf',
            'propertyIsEnumerable',
            'constructor'
        ];
        var equalsConstructorPrototype = function (o) {
            var ctor = o.constructor;
            return ctor && ctor.prototype === o;
        };
        var excludedKeys = {
            $console: true,
            $external: true,
            $frame: true,
            $frameElement: true,
            $frames: true,
            $innerHeight: true,
            $innerWidth: true,
            $outerHeight: true,
            $outerWidth: true,
            $pageXOffset: true,
            $pageYOffset: true,
            $parent: true,
            $scrollLeft: true,
            $scrollTop: true,
            $scrollX: true,
            $scrollY: true,
            $self: true,
            $webkitIndexedDB: true,
            $webkitStorageInfo: true,
            $window: true
        };
        var hasAutomationEqualityBug = (function () {
            /* global window */
            if (typeof window === 'undefined') { return false; }
            for (var k in window) {
                try {
                    if (!excludedKeys['$' + k] && has.call(window, k) && window[k] !== null && typeof window[k] === 'object') {
                        try {
                            equalsConstructorPrototype(window[k]);
                        } catch (e) {
                            return true;
                        }
                    }
                } catch (e) {
                    return true;
                }
            }
            return false;
        }());
        var equalsConstructorPrototypeIfNotBuggy = function (o) {
            /* global window */
            if (typeof window === 'undefined' || !hasAutomationEqualityBug) {
                return equalsConstructorPrototype(o);
            }
            try {
                return equalsConstructorPrototype(o);
            } catch (e) {
                return false;
            }
        };

        function isArgumentsObject(value) {
            var str = toStr.call(value);
            var isArgs = str === '[object Arguments]';
            if (!isArgs) {
                isArgs = str !== '[object Array]' &&
                    value !== null &&
                    typeof value === 'object' &&
                    typeof value.length === 'number' &&
                    value.length >= 0 &&
                    toStr.call(value.callee) === '[object Function]';
            }
            return isArgs;
        }

        return function keys(object) {
            var isFunction = toStr.call(object) === '[object Function]';
            var isArguments = isArgumentsObject(object);
            var isString = toStr.call(object) === '[object String]';
            var theKeys = [];

            if (object === undefined || object === null) {
                throw new TypeError('Cannot convert undefined or null to object');
            }

            var skipProto = hasProtoEnumBug && isFunction;
            if (isString && object.length > 0 && !has.call(object, 0)) {
                for (var i = 0; i < object.length; ++i) {
                    theKeys.push(String(i));
                }
            }

            if (isArguments && object.length > 0) {
                for (var j = 0; j < object.length; ++j) {
                    theKeys.push(String(j));
                }
            } else {
                for (var name in object) {
                    if (!(skipProto && name === 'prototype') && has.call(object, name)) {
                        theKeys.push(String(name));
                    }
                }
            }

            if (hasDontEnumBug) {
                var skipConstructor = equalsConstructorPrototypeIfNotBuggy(object);

                for (var k = 0; k < dontEnums.length; ++k) {
                    if (!(skipConstructor && dontEnums[k] === 'constructor') && has.call(object, dontEnums[k])) {
                        theKeys.push(dontEnums[k]);
                    }
                }
            }
            return theKeys;
        };
    }()));

    // Object.assign
    /* global CreateMethodProperty, Get, ToObject */
    // 19.1.2.1 Object.assign ( target, ...sources )
    CreateMethodProperty(Object, 'assign', function assign(target, source) { // eslint-disable-line no-unused-vars
        // 1. Let to be ? ToObject(target).
        var to = ToObject(target);

        // 2. If only one argument was passed, return to.
        if (arguments.length === 1) {
            return to;
        }

        // 3. Let sources be the List of argument values starting with the second argument
        var sources = Array.prototype.slice.call(arguments, 1);

        // 4. For each element nextSource of sources, in ascending index order, do
        var index1;
        var index2;
        var keys;
        var from;
        for (index1 = 0; index1 < sources.length; index1++) {
            var nextSource = sources[index1];
            // a. If nextSource is undefined or null, let keys be a new empty List.
            if (nextSource === undefined || nextSource === null) {
                keys = [];
                // b. Else,
            } else {
                // i. Let from be ! ToObject(nextSource).
                from = ToObject(nextSource);
                // ii. Let keys be ? from.[[OwnPropertyKeys]]().
                /*
                    This step in our polyfill is not complying with the specification.
                    [[OwnPropertyKeys]] is meant to return ALL keys, including non-enumerable and symbols.
                    TODO: When we have Reflect.ownKeys, use that instead as it is the userland equivalent of [[OwnPropertyKeys]].
                */
                keys = Object.keys(from);
            }

            // c. For each element nextKey of keys in List order, do
            for (index2 = 0; index2 < keys.length; index2++) {
                var nextKey = keys[index2];
                var enumerable;
                try {
                    // i. Let desc be ? from.[[GetOwnProperty]](nextKey).
                    var desc = Object.getOwnPropertyDescriptor(from, nextKey);
                    // ii. If desc is not undefined and desc.[[Enumerable]] is true, then
                    enumerable = desc !== undefined && desc.enumerable === true;
                } catch (e) {
                    // Polyfill.io - We use Object.prototype.propertyIsEnumerable as a fallback
                    // because `Object.getOwnPropertyDescriptor(window.location, 'hash')` causes Internet Explorer 11 to crash.
                    enumerable = Object.prototype.propertyIsEnumerable.call(from, nextKey);
                }
                if (enumerable) {
                    // 1. Let propValue be ? Get(from, nextKey).
                    var propValue = Get(from, nextKey);
                    // 2. Perform ? Set(to, nextKey, propValue, true).
                    to[nextKey] = propValue;
                }
            }
        }
        // 5. Return to.
        return to;
    });

    // Object.setPrototypeOf
    /* global CreateMethodProperty */
    // ES6-shim 0.16.0 (c) 2013-2014 Paul Miller (http://paulmillr.com)
    // ES6-shim may be freely distributed under the MIT license.
    // For more details and documentation:
    // https://github.com/paulmillr/es6-shim/

    // NOTE:  This versions needs object ownership
    //        because every promoted object needs to be reassigned
    //        otherwise uncompatible browsers cannot work as expected
    //
    // NOTE:  This might need es5-shim or polyfills upfront
    //        because it's based on ES5 API.
    //        (probably just an IE <= 8 problem)
    //
    // NOTE:  nodejs is fine in version 0.8, 0.10, and future versions.
    (function () {
        if (Object.setPrototypeOf) { return; }

        /*jshint proto: true */
        // @author    Andrea Giammarchi - @WebReflection

        var getOwnPropertyNames = Object.getOwnPropertyNames;
        var getOwnPropertyDescriptor = Object.getOwnPropertyDescriptor;
        var create = Object.create;
        var defineProperty = Object.defineProperty;
        var getPrototypeOf = Object.getPrototypeOf;
        var objProto = Object.prototype;

        var copyDescriptors = function (target, source) {
            // define into target descriptors from source
            getOwnPropertyNames(source).forEach(function (key) {
                defineProperty(
                    target,
                    key,
                    getOwnPropertyDescriptor(source, key)
                );
            });
            return target;
        };
        // used as fallback when no promotion is possible
        var createAndCopy = function setPrototypeOf(origin, proto) {
            return copyDescriptors(create(proto), origin);
        };
        var set, sPOf;
        try {
            // this might fail for various reasons
            // ignore if Chrome cought it at runtime
            set = getOwnPropertyDescriptor(objProto, '__proto__').set;
            set.call({}, null);
            // setter not poisoned, it can promote
            // Firefox, Chrome
            sPOf = function setPrototypeOf(origin, proto) {
                set.call(origin, proto);
                return origin;
            };
        } catch (e) {
            // do one or more feature detections
            set = { __proto__: null };
            // if proto does not work, needs to fallback
            // some Opera, Rhino, ducktape
            if (set instanceof Object) {
                sPOf = createAndCopy;
            } else {
                // verify if null objects are buggy
                /* eslint-disable no-proto */
                set.__proto__ = objProto;
                /* eslint-enable no-proto */
                // if null objects are buggy
                // nodejs 0.8 to 0.10
                if (set instanceof Object) {
                    sPOf = function setPrototypeOf(origin, proto) {
                        // use such bug to promote
                        /* eslint-disable no-proto */
                        origin.__proto__ = proto;
                        /* eslint-enable no-proto */
                        return origin;
                    };
                } else {
                    // try to use proto or fallback
                    // Safari, old Firefox, many others
                    sPOf = function setPrototypeOf(origin, proto) {
                        // if proto is not null
                        if (getPrototypeOf(origin)) {
                            // use __proto__ to promote
                            /* eslint-disable no-proto */
                            origin.__proto__ = proto;
                            /* eslint-enable no-proto */
                            return origin;
                        } else {
                            // otherwise unable to promote: fallback
                            return createAndCopy(origin, proto);
                        }
                    };
                }
            }
        }
        CreateMethodProperty(Object, 'setPrototypeOf', sPOf);
    }());

    // Promise
    !function (n) { function t(r) { if (e[r]) return e[r].exports; var o = e[r] = { i: r, l: !1, exports: {} }; return n[r].call(o.exports, o, o.exports, t), o.l = !0, o.exports } var e = {}; t.m = n, t.c = e, t.i = function (n) { return n }, t.d = function (n, e, r) { t.o(n, e) || Object.defineProperty(n, e, { configurable: !1, enumerable: !0, get: r }) }, t.n = function (n) { var e = n && n.__esModule ? function () { return n["default"] } : function () { return n }; return t.d(e, "a", e), e }, t.o = function (n, t) { return Object.prototype.hasOwnProperty.call(n, t) }, t.p = "", t(t.s = 100) }({
        100:/*!***********************!*\
  !*** ./src/global.js ***!
  \***********************/
            function (n, t, e) { (function (n) { var t = e(/*! ./yaku */5); try { n.Promise = t, window.Promise = t } catch (r) { } }).call(t, e(/*! ./../~/webpack/buildin/global.js */2)) }, 2:/*!***********************************!*\
  !*** (webpack)/buildin/global.js ***!
  \***********************************/
            function (n, t) { var e; e = function () { return this }(); try { e = e || Function("return this")() || (0, eval)("this") } catch (r) { "object" == typeof window && (e = window) } n.exports = e }, 5:/*!*********************!*\
  !*** ./src/yaku.js ***!
  \*********************/
            function (n, t, e) { (function (t) { !function () { "use strict"; function e() { return rn[q][B] || D } function r(n) { return n && "object" == typeof n } function o(n) { return "function" == typeof n } function i(n, t) { return n instanceof t } function u(n) { return i(n, M) } function c(n, t, e) { if (!t(n)) throw h(e) } function f() { try { return R.apply(S, arguments) } catch (n) { return nn.e = n, nn } } function s(n, t) { return R = n, S = t, f } function a(n, t) { function e() { for (var e = 0; e < o;)t(r[e], r[e + 1]), r[e++] = P, r[e++] = P; o = 0, r.length > n && (r.length = n) } var r = A(n), o = 0; return function (n, t) { r[o++] = n, r[o++] = t, 2 === o && rn.nextTick(e) } } function l(n, t) { var e, r, u, c, f = 0; if (!n) throw h(Q); var a = n[rn[q][z]]; if (o(a)) r = a.call(n); else { if (!o(n.next)) { if (i(n, A)) { for (e = n.length; f < e;)t(n[f], f++); return f } throw h(Q) } r = n } for (; !(u = r.next()).done;)if ((c = s(t)(u.value, f++)) === nn) throw o(r[G]) && r[G](), c.e; return f } function h(n) { return new TypeError(n) } function v(n) { return (n ? "" : V) + (new M).stack } function _(n, t) { var e = "on" + n.toLowerCase(), r = O[e]; H && H.listeners(n).length ? n === Z ? H.emit(n, t._v, t) : H.emit(n, t) : r ? r({ reason: t._v, promise: t }) : rn[n](t._v, t) } function p(n) { return n && n._s } function d(n) { if (p(n)) return new n(tn); var t, e, r; return t = new n(function (n, o) { if (t) throw h(); e = n, r = o }), c(e, o), c(r, o), t } function w(n, t) { var e = !1; return function (r) { e || (e = !0, L && (n[N] = v(!0)), t === Y ? k(n, r) : x(n, t, r)) } } function y(n, t, e, r) { return o(e) && (t._onFulfilled = e), o(r) && (n[J] && _(X, n), t._onRejected = r), L && (t._p = n), n[n._c++] = t, n._s !== $ && on(n, t), t } function m(n) { if (n._umark) return !0; n._umark = !0; for (var t, e = 0, r = n._c; e < r;)if (t = n[e++], t._onRejected || m(t)) return !0 } function j(n, t) { function e(n) { return r.push(n.replace(/^\s+|\s+$/g, "")) } var r = []; return L && (t[N] && e(t[N]), function o(n) { n && K in n && (o(n._next), e(n[K] + ""), o(n._p)) }(t)), (n && n.stack ? n.stack : n) + ("\n" + r.join("\n")).replace(en, "") } function g(n, t) { return n(t) } function x(n, t, e) { var r = 0, o = n._c; if (n._s === $) for (n._s = t, n._v = e, t === U && (L && u(e) && (e.longStack = j(e, n)), un(n)); r < o;)on(n, n[r++]); return n } function k(n, t) { if (t === n && t) return x(n, U, h(W)), n; if (t !== C && (o(t) || r(t))) { var e = s(b)(t); if (e === nn) return x(n, U, e.e), n; o(e) ? (L && p(t) && (n._next = t), p(t) ? T(n, t, e) : rn.nextTick(function () { T(n, t, e) })) : x(n, Y, t) } else x(n, Y, t); return n } function b(n) { return n.then } function T(n, t, e) { var r = s(e, t)(function (e) { t && (t = C, k(n, e)) }, function (e) { t && (t = C, x(n, U, e)) }); r === nn && t && (x(n, U, r.e), t = C) } var P, R, S, C = null, F = "object" == typeof self, O = F ? self : t, E = O.Promise, H = O.process, I = O.console, L = !1, A = Array, M = Error, U = 1, Y = 2, $ = 3, q = "Symbol", z = "iterator", B = "species", D = q + "(" + B + ")", G = "return", J = "_uh", K = "_pt", N = "_st", Q = "Invalid argument", V = "\nFrom previous ", W = "Chaining cycle detected for promise", X = "rejectionHandled", Z = "unhandledRejection", nn = { e: C }, tn = function () { }, en = /^.+\/node_modules\/yaku\/.+\n?/gm, rn = function (n) { var t, e = this; if (!r(e) || e._s !== P) throw h("Invalid this"); if (e._s = $, L && (e[K] = v()), n !== tn) { if (!o(n)) throw h(Q); t = s(n)(w(e, Y), w(e, U)), t === nn && x(e, U, t.e) } }; rn["default"] = rn, function (n, t) { for (var e in t) n[e] = t[e] }(rn.prototype, { then: function (n, t) { if (this._s === undefined) throw h(); return y(this, d(rn.speciesConstructor(this, rn)), n, t) }, "catch": function (n) { return this.then(P, n) }, "finally": function (n) { return this.then(function (t) { return rn.resolve(n()).then(function () { return t }) }, function (t) { return rn.resolve(n()).then(function () { throw t }) }) }, _c: 0, _p: C }), rn.resolve = function (n) { return p(n) ? n : k(d(this), n) }, rn.reject = function (n) { return x(d(this), U, n) }, rn.race = function (n) { var t = this, e = d(t), r = function (n) { x(e, Y, n) }, o = function (n) { x(e, U, n) }, i = s(l)(n, function (n) { t.resolve(n).then(r, o) }); return i === nn ? t.reject(i.e) : e }, rn.all = function (n) { function t(n) { x(o, U, n) } var e, r = this, o = d(r), i = []; return (e = s(l)(n, function (n, u) { r.resolve(n).then(function (n) { i[u] = n, --e || x(o, Y, i) }, t) })) === nn ? r.reject(e.e) : (e || x(o, Y, []), o) }, rn.Symbol = O[q] || {}, s(function () { Object.defineProperty(rn, e(), { get: function () { return this } }) })(), rn.speciesConstructor = function (n, t) { var r = n.constructor; return r ? r[e()] || t : t }, rn.unhandledRejection = function (n, t) { I && I.error("Uncaught (in promise)", L ? t.longStack : j(n, t)) }, rn.rejectionHandled = tn, rn.enableLongStackTrace = function () { L = !0 }, rn.nextTick = F ? function (n) { E ? new E(function (n) { n() }).then(n) : setTimeout(n) } : H.nextTick, rn._s = 1; var on = a(999, function (n, t) { var e, r; return (r = n._s !== U ? t._onFulfilled : t._onRejected) === P ? void x(t, n._s, n._v) : (e = s(g)(r, n._v)) === nn ? void x(t, U, e.e) : void k(t, e) }), un = a(9, function (n) { m(n) || (n[J] = 1, _(Z, n)) }); try { n.exports = rn } catch (cn) { O.Yaku = rn } }() }).call(t, e(/*! ./../~/webpack/buildin/global.js */2)) }
    });
    // String.prototype.includes
    /* global CreateMethodProperty, IsRegExp, RequireObjectCoercible, ToInteger, ToString */
    // 21.1.3.7. String.prototype.includes ( searchString [ , position ] )
    CreateMethodProperty(String.prototype, 'includes', function includes(searchString /* [ , position ] */) {
        'use strict';
        var position = arguments.length > 1 ? arguments[1] : undefined;
        // 1. Let O be ? RequireObjectCoercible(this value).
        var O = RequireObjectCoercible(this);
        // 2. Let S be ? ToString(O).
        var S = ToString(O);
        // 3. Let isRegExp be ? IsRegExp(searchString).
        var isRegExp = IsRegExp(searchString);
        // 4. If isRegExp is true, throw a TypeError exception.
        if (isRegExp) {
            throw new TypeError('First argument to String.prototype.includes must not be a regular expression');
        }
        // 5. Let searchStr be ? ToString(searchString).
        var searchStr = ToString(searchString);
        // 6. Let pos be ? ToInteger(position). (If position is undefined, this step produces the value 0.)
        var pos = ToInteger(position);
        // 7. Let len be the length of S.
        var len = S.length;
        // 8. Let start be min(max(pos, 0), len).
        var start = Math.min(Math.max(pos, 0), len);
        // 9. Let searchLen be the length of searchStr.
        // var searchLength = searchStr.length;
        // 10. If there exists any integer k not smaller than start such that k + searchLen is not greater than len, and for all nonnegative integers j less than searchLen, the code unit at index k+j within S is the same as the code unit at index j within searchStr, return true; but if there is no such integer k, return false.
        return String.prototype.indexOf.call(S, searchStr, start) !== -1;
    });

    // Symbol
    // A modification of https://github.com/WebReflection/get-own-property-symbols
    // (C) Andrea Giammarchi - MIT Licensed

    (function (Object, GOPS, global) {
        'use strict'; //so that ({}).toString.call(null) returns the correct [object Null] rather than [object Window]

        var setDescriptor;
        var id = 0;
        var random = '' + Math.random();
        var prefix = '__\x01symbol:';
        var prefixLength = prefix.length;
        var internalSymbol = '__\x01symbol@@' + random;
        var DP = 'defineProperty';
        var DPies = 'defineProperties';
        var GOPN = 'getOwnPropertyNames';
        var GOPD = 'getOwnPropertyDescriptor';
        var PIE = 'propertyIsEnumerable';
        var ObjectProto = Object.prototype;
        var hOP = ObjectProto.hasOwnProperty;
        var pIE = ObjectProto[PIE];
        var toString = ObjectProto.toString;
        var concat = Array.prototype.concat;
        var cachedWindowNames = Object.getOwnPropertyNames ? Object.getOwnPropertyNames(window) : [];
        var nGOPN = Object[GOPN];
        var gOPN = function getOwnPropertyNames(obj) {
            if (toString.call(obj) === '[object Window]') {
                try {
                    return nGOPN(obj);
                } catch (e) {
                    // IE bug where layout engine calls userland gOPN for cross-domain `window` objects
                    return concat.call([], cachedWindowNames);
                }
            }
            return nGOPN(obj);
        };
        var gOPD = Object[GOPD];
        var create = Object.create;
        var keys = Object.keys;
        var freeze = Object.freeze || Object;
        var defineProperty = Object[DP];
        var $defineProperties = Object[DPies];
        var descriptor = gOPD(Object, GOPN);
        var addInternalIfNeeded = function (o, uid, enumerable) {
            if (!hOP.call(o, internalSymbol)) {
                try {
                    defineProperty(o, internalSymbol, {
                        enumerable: false,
                        configurable: false,
                        writable: false,
                        value: {}
                    });
                } catch (e) {
                    o[internalSymbol] = {};
                }
            }
            o[internalSymbol]['@@' + uid] = enumerable;
        };
        var createWithSymbols = function (proto, descriptors) {
            var self = create(proto);
            gOPN(descriptors).forEach(function (key) {
                if (propertyIsEnumerable.call(descriptors, key)) {
                    $defineProperty(self, key, descriptors[key]);
                }
            });
            return self;
        };
        var copyAsNonEnumerable = function (descriptor) {
            var newDescriptor = create(descriptor);
            newDescriptor.enumerable = false;
            return newDescriptor;
        };
        var get = function get() { };
        var onlyNonSymbols = function (name) {
            return name != internalSymbol &&
                !hOP.call(source, name);
        };
        var onlySymbols = function (name) {
            return name != internalSymbol &&
                hOP.call(source, name);
        };
        var propertyIsEnumerable = function propertyIsEnumerable(key) {
            var uid = '' + key;
            return onlySymbols(uid) ? (
                hOP.call(this, uid) &&
                this[internalSymbol]['@@' + uid]
            ) : pIE.call(this, key);
        };
        var setAndGetSymbol = function (uid) {
            var descriptor = {
                enumerable: false,
                configurable: true,
                get: get,
                set: function (value) {
                    setDescriptor(this, uid, {
                        enumerable: false,
                        configurable: true,
                        writable: true,
                        value: value
                    });
                    addInternalIfNeeded(this, uid, true);
                }
            };
            try {
                defineProperty(ObjectProto, uid, descriptor);
            } catch (e) {
                ObjectProto[uid] = descriptor.value;
            }
            return freeze(source[uid] = defineProperty(
                Object(uid),
                'constructor',
                sourceConstructor
            ));
        };
        var Symbol = function Symbol() {
            var description = arguments[0];
            if (this instanceof Symbol) {
                throw new TypeError('Symbol is not a constructor');
            }
            return setAndGetSymbol(
                prefix.concat(description || '', random, ++id)
            );
        };
        var source = create(null);
        var sourceConstructor = { value: Symbol };
        var sourceMap = function (uid) {
            return source[uid];
        };
        var $defineProperty = function defineProp(o, key, descriptor) {
            var uid = '' + key;
            if (onlySymbols(uid)) {
                setDescriptor(o, uid, descriptor.enumerable ?
                    copyAsNonEnumerable(descriptor) : descriptor);
                addInternalIfNeeded(o, uid, !!descriptor.enumerable);
            } else {
                defineProperty(o, key, descriptor);
            }
            return o;
        };

        var onlyInternalSymbols = function (obj) {
            return function (name) {
                return hOP.call(obj, internalSymbol) && hOP.call(obj[internalSymbol], '@@' + name);
            };
        };
        var $getOwnPropertySymbols = function getOwnPropertySymbols(o) {
            return gOPN(o).filter(o === ObjectProto ? onlyInternalSymbols(o) : onlySymbols).map(sourceMap);
        }
            ;

        descriptor.value = $defineProperty;
        defineProperty(Object, DP, descriptor);

        descriptor.value = $getOwnPropertySymbols;
        defineProperty(Object, GOPS, descriptor);

        descriptor.value = function getOwnPropertyNames(o) {
            return gOPN(o).filter(onlyNonSymbols);
        };
        defineProperty(Object, GOPN, descriptor);

        descriptor.value = function defineProperties(o, descriptors) {
            var symbols = $getOwnPropertySymbols(descriptors);
            if (symbols.length) {
                keys(descriptors).concat(symbols).forEach(function (uid) {
                    if (propertyIsEnumerable.call(descriptors, uid)) {
                        $defineProperty(o, uid, descriptors[uid]);
                    }
                });
            } else {
                $defineProperties(o, descriptors);
            }
            return o;
        };
        defineProperty(Object, DPies, descriptor);

        descriptor.value = propertyIsEnumerable;
        defineProperty(ObjectProto, PIE, descriptor);

        descriptor.value = Symbol;
        defineProperty(global, 'Symbol', descriptor);

        // defining `Symbol.for(key)`
        descriptor.value = function (key) {
            var uid = prefix.concat(prefix, key, random);
            return uid in ObjectProto ? source[uid] : setAndGetSymbol(uid);
        };
        defineProperty(Symbol, 'for', descriptor);

        // defining `Symbol.keyFor(symbol)`
        descriptor.value = function (symbol) {
            if (onlyNonSymbols(symbol))
                throw new TypeError(symbol + ' is not a symbol');
            return hOP.call(source, symbol) ?
                symbol.slice(prefixLength * 2, -random.length) :
                void 0
                ;
        };
        defineProperty(Symbol, 'keyFor', descriptor);

        descriptor.value = function getOwnPropertyDescriptor(o, key) {
            var descriptor = gOPD(o, key);
            if (descriptor && onlySymbols(key)) {
                descriptor.enumerable = propertyIsEnumerable.call(o, key);
            }
            return descriptor;
        };
        defineProperty(Object, GOPD, descriptor);

        descriptor.value = function (proto, descriptors) {
            return arguments.length === 1 || typeof descriptors === "undefined" ?
                create(proto) :
                createWithSymbols(proto, descriptors);
        };
        defineProperty(Object, 'create', descriptor);

        var strictModeSupported = (function () { 'use strict'; return this; }).call(null) === null;
        if (strictModeSupported) {
            descriptor.value = function () {
                var str = toString.call(this);
                return (str === '[object String]' && onlySymbols(this)) ? '[object Symbol]' : str;
            };
        } else {
            descriptor.value = function () {
                // https://github.com/Financial-Times/polyfill-library/issues/164#issuecomment-486965300
                // Polyfill.io this code is here for the situation where a browser does not
                // support strict mode and is executing `Object.prototype.toString.call(null)`.
                // This code ensures that we return the correct result in that situation however,
                // this code also introduces a bug where it will return the incorrect result for
                // `Object.prototype.toString.call(window)`. We can't have the correct result for
                // both `window` and `null`, so we have opted for `null` as we believe this is the more 
                // common situation. 
                if (this === window) {
                    return '[object Null]';
                }

                var str = toString.call(this);
                return (str === '[object String]' && onlySymbols(this)) ? '[object Symbol]' : str;
            };
        }
        defineProperty(ObjectProto, 'toString', descriptor);

        setDescriptor = function (o, key, descriptor) {
            var protoDescriptor = gOPD(ObjectProto, key);
            delete ObjectProto[key];
            defineProperty(o, key, descriptor);
            if (o !== ObjectProto) {
                defineProperty(ObjectProto, key, protoDescriptor);
            }
        };

    }(Object, 'getOwnPropertySymbols', this));

    // Symbol.iterator
    /* global Symbol */
    Object.defineProperty(Symbol, 'iterator', { value: Symbol('iterator') });

    // Symbol.toStringTag
    /* global Symbol */
    Object.defineProperty(Symbol, 'toStringTag', {
        value: Symbol('toStringTag')
    });

    // _Iterator
    /* global Symbol */
    // A modification of https://github.com/medikoo/es6-iterator
    // Copyright (C) 2013-2015 Mariusz Nowak (www.medikoo.com)

    var Iterator = (function () { // eslint-disable-line no-unused-vars
        var clear = function () {
            this.length = 0;
            return this;
        };
        var callable = function (fn) {
            if (typeof fn !== 'function') throw new TypeError(fn + " is not a function");
            return fn;
        };

        var Iterator = function (list, context) {
            if (!(this instanceof Iterator)) {
                return new Iterator(list, context);
            }
            Object.defineProperties(this, {
                __list__: {
                    writable: true,
                    value: list
                },
                __context__: {
                    writable: true,
                    value: context
                },
                __nextIndex__: {
                    writable: true,
                    value: 0
                }
            });
            if (!context) return;
            callable(context.on);
            context.on('_add', this._onAdd.bind(this));
            context.on('_delete', this._onDelete.bind(this));
            context.on('_clear', this._onClear.bind(this));
        };

        Object.defineProperties(Iterator.prototype, Object.assign({
            constructor: {
                value: Iterator,
                configurable: true,
                enumerable: false,
                writable: true
            },
            _next: {
                value: function () {
                    var i;
                    if (!this.__list__) return;
                    if (this.__redo__) {
                        i = this.__redo__.shift();
                        if (i !== undefined) return i;
                    }
                    if (this.__nextIndex__ < this.__list__.length) return this.__nextIndex__++;
                    this._unBind();
                },
                configurable: true,
                enumerable: false,
                writable: true
            },
            next: {
                value: function () {
                    return this._createResult(this._next());
                },
                configurable: true,
                enumerable: false,
                writable: true
            },
            _createResult: {
                value: function (i) {
                    if (i === undefined) return {
                        done: true,
                        value: undefined
                    };
                    return {
                        done: false,
                        value: this._resolve(i)
                    };
                },
                configurable: true,
                enumerable: false,
                writable: true
            },
            _resolve: {
                value: function (i) {
                    return this.__list__[i];
                },
                configurable: true,
                enumerable: false,
                writable: true
            },
            _unBind: {
                value: function () {
                    this.__list__ = null;
                    delete this.__redo__;
                    if (!this.__context__) return;
                    this.__context__.off('_add', this._onAdd.bind(this));
                    this.__context__.off('_delete', this._onDelete.bind(this));
                    this.__context__.off('_clear', this._onClear.bind(this));
                    this.__context__ = null;
                },
                configurable: true,
                enumerable: false,
                writable: true
            },
            toString: {
                value: function () {
                    return '[object Iterator]';
                },
                configurable: true,
                enumerable: false,
                writable: true
            }
        }, {
                _onAdd: {
                    value: function (index) {
                        if (index >= this.__nextIndex__) return;
                        ++this.__nextIndex__;
                        if (!this.__redo__) {
                            Object.defineProperty(this, '__redo__', {
                                value: [index],
                                configurable: true,
                                enumerable: false,
                                writable: false
                            });
                            return;
                        }
                        this.__redo__.forEach(function (redo, i) {
                            if (redo >= index) this.__redo__[i] = ++redo;
                        }, this);
                        this.__redo__.push(index);
                    },
                    configurable: true,
                    enumerable: false,
                    writable: true
                },
                _onDelete: {
                    value: function (index) {
                        var i;
                        if (index >= this.__nextIndex__) return;
                        --this.__nextIndex__;
                        if (!this.__redo__) return;
                        i = this.__redo__.indexOf(index);
                        if (i !== -1) this.__redo__.splice(i, 1);
                        this.__redo__.forEach(function (redo, i) {
                            if (redo > index) this.__redo__[i] = --redo;
                        }, this);
                    },
                    configurable: true,
                    enumerable: false,
                    writable: true
                },
                _onClear: {
                    value: function () {
                        if (this.__redo__) clear.call(this.__redo__);
                        this.__nextIndex__ = 0;
                    },
                    configurable: true,
                    enumerable: false,
                    writable: true
                }
            }));

        Object.defineProperty(Iterator.prototype, Symbol.iterator, {
            value: function () {
                return this;
            },
            configurable: true,
            enumerable: false,
            writable: true
        });
        Object.defineProperty(Iterator.prototype, Symbol.toStringTag, {
            value: 'Iterator',
            configurable: false,
            enumerable: false,
            writable: true
        });

        return Iterator;
    }());

    // _ArrayIterator
    /* global Iterator */
    // A modification of https://github.com/medikoo/es6-iterator
    // Copyright (C) 2013-2015 Mariusz Nowak (www.medikoo.com)

    var ArrayIterator = (function () { // eslint-disable-line no-unused-vars

        var ArrayIterator = function (arr, kind) {
            if (!(this instanceof ArrayIterator)) return new ArrayIterator(arr, kind);
            Iterator.call(this, arr);
            if (!kind) kind = 'value';
            else if (String.prototype.includes.call(kind, 'key+value')) kind = 'key+value';
            else if (String.prototype.includes.call(kind, 'key')) kind = 'key';
            else kind = 'value';
            Object.defineProperty(this, '__kind__', {
                value: kind,
                configurable: false,
                enumerable: false,
                writable: false
            });
        };
        if (Object.setPrototypeOf) Object.setPrototypeOf(ArrayIterator, Iterator.prototype);

        ArrayIterator.prototype = Object.create(Iterator.prototype, {
            constructor: {
                value: ArrayIterator,
                configurable: true,
                enumerable: false,
                writable: true
            },
            _resolve: {
                value: function (i) {
                    if (this.__kind__ === 'value') return this.__list__[i];
                    if (this.__kind__ === 'key+value') return [i, this.__list__[i]];
                    return i;
                },
                configurable: true,
                enumerable: false,
                writable: true
            },
            toString: {
                value: function () {
                    return '[object Array Iterator]';
                },
                configurable: true,
                enumerable: false,
                writable: true
            }
        });

        return ArrayIterator;
    }());

    // NodeList.prototype.@@iterator
    /* global Symbol, ArrayIterator*/
    NodeList.prototype[Symbol.iterator] = function () {
        return new ArrayIterator(this);
    };
})
    .call('object' === typeof window && window || 'object' === typeof self && self || 'object' === typeof global && global || {});
