
Here is a quick example of how to use [sass mixins](https://sass-lang.com/documentation/at-rules/mixin/):

```scss
@mixin larger-screen {
    @media screen and (min-width: 768px) {
        @content; // This will inject whatever styles you pass in
    }
}

.btn-stretch {
    width: 100%;
}

@include larger-screen {
    .btn-stretch {
        width: 100px;
    }
}


@mixin custom-shadow {
    box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.18);
}

.custom-shadow {
    @include custom-shadow;
}
```