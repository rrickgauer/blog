Recently, I've found myself doing a lot of work in [Flask](https://flask.palletsprojects.com/en/2.1.x/). Because of this, I've had to devise a way to serialize/map dictionaries to dataclasses. This is what I've come up with.

## Dataclass

Let's start out with a basic data class.

```py
from dataclasses import dataclass
from datetime import datetime
from decimal import Decimal
from uuid import UUID

@dataclass
class Watch:
    id         : UUID                 = None
    tag        : str                  = None
    symbol     : str                  = None
    price      : Decimal              = None
    email      : str                  = None
    created_on : datetime             = datetime.now()
    closed_on  : datetime             = None
```

## Serializer

Here is the base serializer class that all future serializers should inherit from:

```py
#------------------------------------------------------
# Base serializer class
#------------------------------------------------------
class SerializerBase:
    DomainModel: dataclass = object

    #------------------------------------------------------
    # Constructor
    #
    # Args:
    #   - dictionary: a dict of the data to serialize into the Domain Model
    #   - domain_model: an instance of the class' DomainModel or None
    #------------------------------------------------------
    def __init__(self, dictionary: dict, domain_model = None):
        self.dictionary = dictionary
        
        # if the given domain_model is not null, set the object's domain_model field to it
        # otherwise, call the contructor of the class' DomainModel
        self.domain_model = domain_model or self.DomainModel()

    #------------------------------------------------------
    # Serialize the object's dictionary into the sub-class' domain model
    #------------------------------------------------------
    def serialize(self) -> dataclass:
        model = self.domain_model

        # get a list of all the Model's attributes
        model_keys = list(model.__annotations__.keys())

        # if the dict's key is an attribute in the model, copy over the value
        for key, value in self.dictionary.items():
            if not key in model_keys:
                continue
            elif not value:
                setattr(model, key, None)
            else:
                setattr(model, key, value or None)

        return model
```



Now, let's make one more class that will inherit the `BaseSerializer` class and serialize a dictionary into a `Watch` object:

```py
import models

class WatchSerializer(SerializerBase):
    DomainModel = models.Watch
```

If you want to do some additional work on the object before returning it:

```py
import models
from datetime import datetime

class WatchSerializer(SerializerBase):
    DomainModel = models.Watch

    def serialize(self) -> models.Watch:
        model = super().serialize()

        if model.closed_on == None:
            model.closed_on = datetime.now()

        return model
```


## Usage

Now, to use the `WatchSerializer` class:

```py
from serializers import WatchSerializer
from models import Watch

d = dict(
    tag = 'tag value',
    symbol = 'symbol',
    price = 44.24,
    email = 'test@example.com,
    closed_on = None,
)

serializer = WatchSerializer(d)
watch = serializer.serialize()
print(watch)
```